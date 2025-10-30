using ManageProperty.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManageProperty.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string account, string email, string password)
        {
            var result = _service.ValidateCredentials(account, email, password);Console.WriteLine(result == null 
    ? "Result is NULL" 
    : $"Result: {result.Value.role} / {result.Value.email}");


            if (result != null && result.Value.isValid)
            {
                HttpContext.Session.SetString("UserEmail", result.Value.email);
                HttpContext.Session.SetInt32("UserId", result.Value.userId);
                HttpContext.Session.SetString("UserRole", result.Value.role);
                HttpContext.Session.SetString("UserName", result.Value.userName);

                return RedirectToAction("MainPage", $"{result.Value.role}s");
            }
            

            ViewBag.SelectedAccount = account;
            ViewBag.LoginEror = "Invalid credentials, please try again.";

            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
