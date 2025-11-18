using ManageProperty.Models;
using ManageProperty.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManageProperty.Filters;
namespace ManageProperty.Controllers
{
    [SessionCheckFilter("Manager")]
    public class ApartmentsController : Controller
    {
        private readonly IApartmentService _service;

        public ApartmentsController(IApartmentService service)
        {
            _service = service;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            var managerId = HttpContext.Session.GetInt32("UserId");
            if (managerId == null)
                return RedirectToAction("Login", "Account");

            var apartments = await _service.GetApartmentsForManagerAsync(managerId.Value);
            return View(apartments);
        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var apartment = await _service.GetApartmentByIdAsync(id);
            if (apartment == null) return NotFound();

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create() => View();

        // POST: Apartments/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Apartment apartment)
        {
            if (!ModelState.IsValid) return View(apartment);

            await _service.CreateApartmentAsync(apartment);
            return RedirectToAction(nameof(SearchByStatus));
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var apartment = await _service.GetApartmentByIdAsync(id);
            if (apartment == null) return NotFound();

            return View(apartment);
        }

        // POST: Apartments/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Apartment apartment)
        {
            if (id != apartment.ApartmentId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(apartment);

            var updated = await _service.UpdateApartmentAsync(apartment);
            if (!updated) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var apartment = await _service.GetApartmentByIdAsync(id);
            if (apartment == null) return NotFound();

            return View(apartment);
        }

        // POST: Apartments/Delete
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteApartmentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Apartments/SearchByStatus
        [SessionCheckFilter("Manager", "Tenant")]
        public async Task<IActionResult> SearchByStatus(string? status)
        {
            var managerId = HttpContext.Session.GetInt32("UserId");
            if (managerId == null)
                return RedirectToAction("Login", "Account");

            var apartments = await _service.SearchByStatusAsync(managerId.Value, status);
            var statusList = await _service.GetStatusesAsync(managerId.Value);
            ViewBag.StatusList = new SelectList(statusList);
            return View(apartments);
        }

        // GET: Apartments/Sort
        [SessionCheckFilter("Manager", "Tenant")]
        public async Task<IActionResult> Sort(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortOptions = new SelectList(
                new List<SelectListItem>
                {
                    new() { Text = "Price (Low to High)", Value = "price_asc" },
                    new() { Text = "Price (High to Low)", Value = "price_desc" },
                    new() { Text = "Rooms (Few to Many)", Value = "rooms_asc" },
                    new() { Text = "Rooms (Many to Few)", Value = "rooms_desc" }
                },
                "Value", "Text", sortOrder
            );

            var apartments = await _service.SortApartmentsAsync(sortOrder);
            return View(apartments);
        }

        // GET: Apartments/DetailsTenant/5
        [SessionCheckFilter("Tenant")]
        public IActionResult DetailsTenant(int id)
        {
            var apartment = _service.GetApartmentWithBuilding(id);
            if (apartment == null)
                return NotFound();

            return View(apartment);
        }
    }
}
