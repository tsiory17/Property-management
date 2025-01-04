using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManageProperty.Models;
using ManageProperty.Data;

namespace ManageProperty.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly EstateDbContext _context;

        public ApartmentsController(EstateDbContext context)
        {
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {

            var managerId = HttpContext.Session.GetInt32("UserId");

            if (managerId == null) { return RedirectToAction("Login", "Account"); }

            var buildings = await _context.Buildings.Where(b => b.ManagerId == managerId).ToListAsync();


            var buildingIds = buildings.Select(b => b.BuildingId).ToList();

            // Retrieve the apartments in the buildings owned by the manager
            var apartments = await _context.Apartments
                .Where(a => buildingIds.Contains(a.BuildingId))
                .ToListAsync();

            // Return the apartments to the view
            return View(apartments);

        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApartmentId,BuildingId,NumberOfRooms,Rent,Status")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SearchByStatus));
            }
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApartmentId,BuildingId,NumberOfRooms,Rent,Status")] Apartment apartment)
        {
            if (id != apartment.ApartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.ApartmentId))
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
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(e => e.ApartmentId == id);
        }

        public async Task<IActionResult> SearchByStatus(string status)
        {
            // Retrieve the manager's ID from the session
            var managerId = HttpContext.Session.GetInt32("UserId");

            // Redirect to login if the manager ID is not in the session
            if (managerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get the buildings managed by the logged-in manager
            var buildings = await _context.Buildings
                .Where(b => b.ManagerId == managerId)
                .ToListAsync();

            // Extract building IDs
            var buildingIds = buildings.Select(b => b.BuildingId).ToList();

            // Query apartments associated with the manager's buildings
            var apartmentsQuery = _context.Apartments
                .Where(a => buildingIds.Contains(a.BuildingId));

            // Filter apartments by status if provided
            if (!string.IsNullOrEmpty(status))
            {
                apartmentsQuery = apartmentsQuery.Where(
                    a => a.Status.ToLower() == status.ToLower());
            }

            // Execute the query to retrieve the apartments
            var apartments = await apartmentsQuery.ToListAsync();

            // Create a distinct list of statuses for the dropdown
            var statusList = await _context.Apartments
                .Where(a => buildingIds.Contains(a.BuildingId))
                .Select(a => a.Status)
                .Distinct()
                .ToListAsync();

            // Pass the status list to the view
            ViewBag.StatusList = new SelectList(statusList);

            // Return the filtered apartments to the view
            return View(apartments);
        }

        public IActionResult Sort(string sortOrder)
        {
            // Store the current sort order in ViewBag
            ViewBag.CurrentSort = sortOrder;

            // Create a list of sorting options and pass it to ViewBag
            ViewBag.SortOptions = new SelectList(
                new List<SelectListItem>
                {
        new SelectListItem { Text = "Price (Low to High)", Value = "price_asc" },
        new SelectListItem { Text = "Price (High to Low)", Value = "price_desc" },
        new SelectListItem { Text = "Rooms (Few to Many)", Value = "rooms_asc" },
        new SelectListItem { Text = "Rooms (Many to Few)", Value = "rooms_desc" }
                },
                "Value", // Value property for the SelectList
                "Text",  // Text property for the SelectList
                sortOrder // Selected value
            );

            // Fetch all apartments
            var apartments = from a in _context.Apartments
                             select a;

            // Apply sorting based on the sortOrder parameter
            switch (sortOrder)
            {
                case "price_asc":
                    apartments = apartments.OrderBy(a => a.Rent);
                    break;

                case "price_desc":
                    apartments = apartments.OrderByDescending(a => a.Rent);
                    break;

                case "rooms_asc":
                    apartments = apartments.OrderBy(a => a.NumberOfRooms);
                    break;

                case "rooms_desc":
                    apartments = apartments.OrderByDescending(a => a.NumberOfRooms);
                    break;

                default:
                    apartments = apartments.OrderBy(a => a.Rent); // Default sorting
                    break;
            }

            // Return the sorted list of apartments to the view
            return View(apartments.ToList());

        }
        public IActionResult DetailsTenant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = (from a in _context.Apartments
                             join b in _context.Buildings on a.BuildingId equals b.BuildingId
                             where a.ApartmentId == id
                             select new ApartmentViewModel
                             {
                                 ApartmentId = a.ApartmentId,
                                 BuildingId = b.BuildingId,
                                 Rent = a.Rent,
                                 NumberOfRooms = a.NumberOfRooms,
                                 Status = a.Status,
                                 Address = b.Address,
                                 City = b.City,
                                 ZipCode = b.Zip
                             }).FirstOrDefault();

            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }







    }
}
