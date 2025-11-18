using ManageProperty.Filters;
using ManageProperty.Models;
using ManageProperty.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManageProperty.Controllers
{
     //Owner will access the majority of the actions
    public class ManagersController : Controller
    {
        private readonly IManagerService _service;

        public ManagersController(IManagerService service)
        {
            _service = service;
        }

        // GET: Managers
        [SessionCheckFilter("Owner")]
        public async Task<IActionResult> Index()
        {
            var managers = await _service.GetAllManagersAsync();
            return View(managers);
        }

        // GET: Managers/Details/5
        [SessionCheckFilter("Owner")]
        public async Task<IActionResult> Details(int id)
        {
            var manager = await _service.GetManagerByIdAsync(id);
            if (manager == null) return NotFound();
            return View(manager);
        }

        // GET: Managers/Create
        [SessionCheckFilter("Owner")]
        public IActionResult Create() => View();

        // POST: Managers/Create
        [SessionCheckFilter("Owner")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Manager manager)
        {
            if (!ModelState.IsValid) return View(manager);

            await _service.CreateManagerAsync(manager);
            return RedirectToAction(nameof(Index));
        }

        // GET: Managers/Edit/5
        [SessionCheckFilter("Owner")]
        public async Task<IActionResult> Edit(int id)
        {
            var manager = await _service.GetManagerByIdAsync(id);
            if (manager == null) return NotFound();
            return View(manager);
        }

        // POST: Managers/Edit/5
        [SessionCheckFilter("Owner")]
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
        [SessionCheckFilter("Owner")]
        public async Task<IActionResult> Delete(int id)
        {
            var manager = await _service.GetManagerByIdAsync(id);
            if (manager == null) return NotFound();
            return View(manager);
        }

        // POST: Managers/Delete/5
        [SessionCheckFilter("Owner")]
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteManagerAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Managers/Search
        [HttpPost]
        [SessionCheckFilter("Owner")]
        public IActionResult Search(string? searchTerm)
        {
            var results = _service.SearchManagers(searchTerm);
            if (!results.Any())
                ViewBag.Message = "No manager found for the given search term.";

            return View(results);
        }
        [SessionCheckFilter("Manager")]
        public IActionResult MainPage()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
