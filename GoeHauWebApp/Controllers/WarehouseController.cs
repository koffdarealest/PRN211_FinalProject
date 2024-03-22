using GoeHauWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoeHauWebApp.Controllers
{
    public class WarehouseController : Controller
    {
        GoeHauContext _context = new GoeHauContext();
        public IActionResult Index()
        {
            var warehouses = _context.Warehouses.ToList();
            ViewBag.Warehouses = warehouses;
            return View();
        }
    }
}
