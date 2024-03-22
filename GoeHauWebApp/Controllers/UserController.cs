using GoeHauWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoeHauWebApp.Controllers
{
    public class UserController : Controller
    {
        GoeHauContext _context = new GoeHauContext();
        public IActionResult Index()
        {
            var Users = _context.Users.ToList();
            ViewBag.Users = Users;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }   

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
