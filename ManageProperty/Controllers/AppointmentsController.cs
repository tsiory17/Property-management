using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManageProperty.Data;
using ManageProperty.Models;

namespace ManageProperty.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly EstateDbContext _context;

        public AppointmentsController(EstateDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appointments.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,ScheduleId,TenantId,Status")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }

        // Method to show available schedules for booking for the tenant
        public IActionResult BookAppointment(int buildingId)
        {
            var building = _context.Buildings.Find(buildingId);
            if (building == null)
            {
                return NotFound();
            }

            var managerId = building.ManagerId;
            var availableSchedules = _context.Schedules
                .Where(s => s.ManagerId == managerId && s.Status == "available")
                .ToList();
            ViewBag.ManagerId = managerId;
            ViewBag.BuildingId = buildingId;
            ViewBag.TenantId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            return View(availableSchedules);
        }

        // Method to book an appointment for tenant 
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var schedule = _context.Schedules.Find(appointment.ScheduleId);
                if (schedule != null && schedule.Status == "available")
                {
                    // Capture TenantId from session
                    var tenantId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();

                    if (tenantId == 0)
                    {
                        // Handle the case where tenantId is not found in session
                        ModelState.AddModelError("", "Tenant ID not found in session.");
                        return View(appointment);
                    }

                    // Update appointment and schedule details
                    appointment.TenantId = tenantId;
                    schedule.Status = "booked";
                    appointment.Status = "pending";

                    // Save changes to the database
                    _context.Update(schedule);
                    _context.Add(appointment);
                    _context.SaveChanges();

                    // Redirect to the TenantAppointments action
                    return RedirectToAction(nameof(TenantAppointments), new { tenantId = appointment.TenantId });
                }
            }
            // If we reach here, return the view with the model
            return View(appointment);
        }
        public IActionResult TenantAppointments(int tenantId)
        {
            var sessionTenantId = HttpContext.Session.GetInt32("UserId"); // Get the tenant's ID from the session
            // Redirect to login if tenant ID is not in the session
            if (sessionTenantId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Query appointments for the logged-in tenant
            var appointments = from a in _context.Appointments
                               join s in _context.Schedules
                               on a.ScheduleId equals s.ScheduleId
                               where a.TenantId == sessionTenantId
                               select new AppointmentDetailsModel
                               {
                                   AppointmentId = a.AppointmentId,
                                   ScheduleId = a.ScheduleId,
                                   TenantId = a.TenantId,
                                   Status = a.Status,
                                   Date = s.Date,
                                   StartTime = s.StartTime,
                                   EndTime = s.EndTime
                               };

            // Return the appointments list to the view
            return View(appointments.ToList());
        }

        [HttpPost]
        public IActionResult UpdateStatus(int appointmentId, string status)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            if (appointment != null && (status == "accepted" || status == "rejected"))
            {
                appointment.Status = status;

                var schedule = _context.Schedules.Find(appointment.ScheduleId);
                if (schedule != null)
                {
                    if (status == "accepted")
                    {
                        // Optionally, perform any actions on accepted appointments
                        // For example: schedule.Status = "unavailable";
                    }
                    else if (status == "rejected")
                    {
                        // Keep the schedule available for booking if the appointment is rejected
                        schedule.Status = "available";
                        _context.Update(schedule);
                    }
                }

                _context.Update(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(ManagerAppointments), new { managerId = schedule?.ManagerId });
            }
            return View(appointment);
        }
        public IActionResult ManagerAppointments()
        {

            var managerId = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            if (managerId == 0)
            {
                // Handle the case where managerId is not found in session
                return NotFound("Manager ID not found in session.");
            }

            var appointments = from a in _context.Appointments
                               join s in _context.Schedules on a.ScheduleId equals s.ScheduleId
                               join t in _context.Tenants on a.TenantId equals t.TenantId
                               where s.ManagerId == managerId
                               select new AppointmentDetailsModel
                               {
                                   AppointmentId = a.AppointmentId,
                                   ScheduleId = a.ScheduleId,
                                   TenantId = a.TenantId,
                                   TenantName = t.FirstName + " " + t.LastName,
                                   Status = a.Status,
                                   Date = s.Date,
                                   StartTime = s.StartTime,
                                   EndTime = s.EndTime
                               };

            return View(appointments.ToList());
        }

        public IActionResult ShowApprovedAppointments()
        {
            var approvedAppointments = from a in _context.Appointments
                                       join s in _context.Schedules on a.ScheduleId equals s.ScheduleId
                                       join t in _context.Tenants on a.TenantId equals t.TenantId
                                       where a.Status == "accepted"
                                       select new AppointmentDetailsModel
                                       {
                                           AppointmentId = a.AppointmentId,
                                           ScheduleId = a.ScheduleId,
                                           TenantId = a.TenantId,
                                           TenantName = t.FirstName + " " + t.LastName,
                                           Status = a.Status,
                                           Date = s.Date,
                                           StartTime = s.StartTime,
                                           EndTime = s.EndTime
                                       };

            return View(approvedAppointments.ToList());
        }

        public IActionResult SearchAppointmentById(int appointmentId)
        {
            var appointment = (from a in _context.Appointments
                               join s in _context.Schedules on a.ScheduleId equals s.ScheduleId
                               join t in _context.Tenants on a.TenantId equals t.TenantId
                               where a.AppointmentId == appointmentId
                               select new AppointmentDetailsModel
                               {
                                   AppointmentId = a.AppointmentId,
                                   ScheduleId = a.ScheduleId,
                                   TenantId = a.TenantId,
                                   TenantName = t.FirstName + " " + t.LastName,
                                   Status = a.Status,
                                   Date = s.Date,
                                   StartTime = s.StartTime,
                                   EndTime = s.EndTime
                               }).FirstOrDefault();

            return View(appointment);
        }
    }
}
