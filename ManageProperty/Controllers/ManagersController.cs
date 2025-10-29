using ManageProperty.Filters;
using ManageProperty.Models;
using ManageProperty.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManageProperty.Controllers
{
    [SessionCheckFilter("Owner")] // only owners can access
    public class ManagersController : Controller
    {
        private readonly IManagerService _service;

        public ManagersController(IManagerService service)
        {
            _service = service;
        }

        // GET: Managers
        public async Task<IActionResult> Index()
        {
            var managers = await _service.GetAllManagersAsync();
            return View(managers);
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var manager = await _service.GetManagerByIdAsync(id);
            if (manager == null) return NotFound();
            return View(manager);
        }

        // GET: Managers/Create
        public IActionResult Create() => View();

        // POST: Managers/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Manager manager)
        {
            if (!ModelState.IsValid) return View(manager);

            await _service.CreateManagerAsync(manager);
            return RedirectToAction(nameof(Index));
        }

        // GET: Managers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var manager = await _service.GetManagerByIdAsync(id);
            if (manager == null) return NotFound();
            return View(manager);
        }

        // POST: Managers/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Manager manager)
        {
            if (id != manager.ManagerId) return NotFound();
            if (!ModelState.IsValid) return View(manager);

            var updated = await _service.UpdateManagerAsync(manager);
            if (!updated) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: Managers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var manager = await _service.GetManagerByIdAsync(id);
            if (manager == null) return NotFound();
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteManagerAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Managers/Search
        [HttpPost]
        public IActionResult Search(string? searchTerm)
        {
            var results = _service.SearchManagers(searchTerm);
            if (!results.Any())
                ViewBag.Message = "No manager found for the given search term.";

            return View(results);
        }

        public IActionResult MainPage()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
