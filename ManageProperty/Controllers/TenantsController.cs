using ManageProperty.Models;
using ManageProperty.Services;
using Microsoft.AspNetCore.Mvc;
using ManageProperty.Filters;

namespace ManageProperty.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ITenantService _service;

        public TenantsController(ITenantService service)
        {
            _service = service;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
            var tenants = await _service.GetAllTenantsAsync();
            return View(tenants);
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var tenant = await _service.GetTenantByIdAsync(id);
            if (tenant == null) return NotFound();
            return View(tenant);
        }

        // GET: Tenants/Create
        public IActionResult Create() => View();

        // POST: Tenants/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tenant tenant)
        {
            if (!ModelState.IsValid) return View(tenant);

            await _service.CreateTenantAsync(tenant);
            return RedirectToAction(nameof(Index));
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var tenant = await _service.GetTenantByIdAsync(id);
            if (tenant == null) return NotFound();
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tenant tenant)
        {
            if (id != tenant.TenantId) return NotFound();
            if (!ModelState.IsValid) return View(tenant);

            var updated = await _service.UpdateTenantAsync(tenant);
            if (!updated) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var tenant = await _service.GetTenantByIdAsync(id);
            if (tenant == null) return NotFound();
            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteTenantAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Tenants/Search
        [HttpPost]
        public IActionResult Search(string? searchTerm)
        {
            var results = _service.SearchTenants(searchTerm);
            if (!results.Any())
                ViewBag.Message = "No tenant found for the given search term.";

            return View(results);
        }

        // GET: Tenants/Register
        public IActionResult Register() => View();

        // POST: Tenants/Register
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Tenant tenant)
        {
            if (!ModelState.IsValid) return View(tenant);

            var success = await _service.RegisterTenantAsync(tenant);
            if (!success)
            {
                ViewBag.Message = "Email already exists. Please use another.";
                return View(tenant);
            }

            return RedirectToAction("Login", "Account");
        }
        [SessionCheckFilter("Tenant")]
        public IActionResult MainPage()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
