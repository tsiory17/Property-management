using ManageProperty.Models;
using ManageProperty.Services;
using Microsoft.AspNetCore.Mvc;
using ManageProperty.Filters;
namespace ManageProperty.Controllers
{
    [SessionCheckFilter("Manager")]
    public class BuildingsController : Controller
    {
        private readonly IBuildingService _service;

        public BuildingsController(IBuildingService service)
        {
            _service = service;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            var managerId = HttpContext.Session.GetInt32("UserId");
            if (managerId == null)
                return RedirectToAction("Login", "Account");

            var buildings = await _service.GetBuildingsForManagerAsync(managerId.Value);
            return View(buildings);
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var building = await _service.GetBuildingByIdAsync(id);
            if (building == null)
                return NotFound();

            return View(building);
        }

        // GET: Buildings/Create
        public IActionResult Create() => View();

        // POST: Buildings/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Building building)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }

                return View(building);
            }

            await _service.CreateBuildingAsync(building);
            return RedirectToAction(nameof(Index));
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var building = await _service.GetBuildingByIdAsync(id);
            if (building == null)
                return NotFound();

            return View(building);
        }

        // POST: Buildings/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Building building)
        {
            if (id != building.BuildingId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(building);

            var updated = await _service.UpdateBuildingAsync(building);
            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var building = await _service.GetBuildingByIdAsync(id);
            if (building == null)
                return NotFound();

            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteBuildingAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
