using GoeHauWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoeHauWebApp.Controllers
{
    public class ProductController : Controller
    {
        private GoeHauContext _context = new GoeHauContext();

        public ProductController(GoeHauContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            var inStock = _context.InStocks.ToList();
            ViewBag.InStock = inStock;
            ViewBag.Products = products;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var inStock = _context.InStocks.Where(p => p.ProductId == id).ToList();
            ViewBag.InStocks = inStock;
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }   
            var product = _context.Products.Find(id); 
            if (product == null)
            {
                return NotFound();
            }
            var inStocks = _context.InStocks.Include(p => p.Product).Where(p => p.ProductId == id).ToList();
            ViewBag.InStocks = inStocks;
            var warehouses = _context.Warehouses.ToList();
            ViewBag.Warehouses = warehouses;
            return View(product);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult DeleteAction(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                var inStocks = _context.InStocks.Where(p => p.ProductId == id).ToList();
                foreach (var inStock in inStocks)
                {
                    _context.InStocks.Remove(inStock);
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(InStock InStock)
        {
            _context.InStocks.Add(InStock);    
            Product product = InStock.Product;
            _context.Products.Add(product);           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Product product, string unit)
        {
            var inStocks = _context.InStocks.Where(p => p.ProductId == product.Id).ToList();
            foreach (var item in inStocks)
            {
                item.UnitInStock = long.Parse(unit);
                _context.InStocks.Update(item);
            }
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
