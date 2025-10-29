
using ManageProperty.Data;
using ManageProperty.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManageProperty.Controllers
{
    public class AccountController : Controller
    {
        protected readonly EstateDbContext _d;
        public AccountController(EstateDbContext d)
        {
            _d = d;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String account, String Email, String password)
        {
            if (account == "owner")
            {
                var owner = _d.Owners.FirstOrDefault(o => o.Email.ToLower() == Email.ToLower() && o.Password == password);
                if (owner != null)
                {
                    HttpContext.Session.SetString("UserEmail", owner.Email);
                    HttpContext.Session.SetInt32("UserId", owner.OwnerId);
                    HttpContext.Session.SetString("UserRole", "Owner");
                    HttpContext.Session.SetString("UserName", owner.FirstName + " " + owner.LastName);
                    return RedirectToAction("MainPage", "Owners");
                }
            }
            else if (account == "manager")
            {
                var manager = _d.Managers.FirstOrDefault(m => m.Email.ToLower() == Email.ToLower() && m.Password == password);
                if (manager != null)
                {
                    HttpContext.Session.SetString("UserEmail", manager.Email);
                    HttpContext.Session.SetInt32("UserId", manager.ManagerId);
                    HttpContext.Session.SetString("UserRole", "Manager");
                    HttpContext.Session.SetString("UserName", manager.FirstName + " " + manager.LastName);
                    Console.WriteLine("Hello");
                    return RedirectToAction("MainPage", "Managers");
                }
            }
            else if (account == "tenant")
            {
                var tenant = _d.Tenants.FirstOrDefault(t => t.Email.ToLower() == Email.ToLower() && t.Password == password);
                if (tenant != null)
                {
                    HttpContext.Session.SetString("UserEmail", tenant.Email);
                    HttpContext.Session.SetInt32("UserId", tenant.TenantId);
                    HttpContext.Session.SetString("UserRole", "Tenant");
                    HttpContext.Session.SetString("UserName", tenant.FirstName + " " + tenant.LastName);
                    return RedirectToAction("MainPage", "Tenants");
                }
            }

            ViewBag.SelectedAccount = account;
            ViewBag.LoginEror = "Invalid credentials, please try again ";

            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
