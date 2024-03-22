using GoeHauWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoeHauWebApp.Controllers
{
    public class TruckController : Controller
    {
        GoeHauContext _context = new GoeHauContext();

        public TruckController(GoeHauContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            List<User> AllDriver = _context.Users.Where(p => p.Role == 4).ToList();
            var trucks = _context.Trucks.ToList();
            List<User> WorkedDriver = new List<User>();
            foreach(var truck in trucks)
            {
                if(truck.Driver != null)
                {
                    WorkedDriver.Add(truck.Driver);
                }
            }
            List<User> AvailableDriver = new List<User>();
            foreach(var driver in AllDriver)
            {
                if(!WorkedDriver.Contains(driver))
                {
                    AvailableDriver.Add(driver);
                }
            }
            ViewBag.Drivers = AvailableDriver;
            return View();
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }
        public IActionResult DeleteAction(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }
            else
            {
                _context.Trucks.Remove(truck);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }   

        public IActionResult Index()
        {
            var trucks = _context.Trucks.ToList();
            ViewBag.Trucks = trucks;
            var users = _context.Users.ToList();
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Truck truck)
        {
            _context.Trucks.Add(truck);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
