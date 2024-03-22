using GoeHauWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoeHauWebApp.Controllers
{
    public class LoginController : Controller
    {

        GoeHauContext _context = new GoeHauContext();
        public IActionResult Login()
        {
            return View();
        }

        public LoginController(GoeHauContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("Id", user.Id.ToString());
                HttpContext.Session.SetString("Role", user.Role.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }   
        }
    }
}
