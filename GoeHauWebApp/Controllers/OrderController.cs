using GoeHauWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoeHauWebApp.Controllers
{
    public class OrderController : Controller
    {
        GoeHauContext _context = new GoeHauContext();

        public OrderController(GoeHauContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var Warehouses = _context.Warehouses.ToList();  
            var InStocks = _context.InStocks.ToList();
            var Trucks = _context.Trucks.ToList();
            var Products = _context.Products.ToList();

            ViewBag.Warehouses = Warehouses;
            ViewBag.InStocks = InStocks;
            ViewBag.Trucks = Trucks;
            ViewBag.Products = Products;
            return View();
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        public IActionResult DeleteAction(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                _context.Orders.Remove(order);
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
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            var Warehouses = _context.Warehouses.ToList();
            var InStocks = _context.InStocks.ToList();
            var Trucks = _context.Trucks.ToList();
            var Products = _context.Products.ToList();

            ViewBag.Warehouses = Warehouses;
            ViewBag.InStocks = InStocks;
            ViewBag.Trucks = Trucks;
            ViewBag.Products = Products;
            return View(order);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }   

        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            var products = _context.Products.ToList();
            var truck = _context.Trucks.ToList();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            ViewBag.Trucks = truck;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            var inStockOfProduct = _context.InStocks.FirstOrDefault(i => i.ProductId == order.ProductId);
            var product = _context.Products.FirstOrDefault(p => p.Id == order.ProductId);
            if (ModelState.IsValid)
            {
                if (order.Quantity > 0 && order.Quantity <= inStockOfProduct.UnitInStock)
                {
                    order.TotalPrice = order.Quantity * product.Price;
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                }
                else
                {
                    ViewBag.Error = "Số lượng sản phẩm không hợp lệ";
                }
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            var inStockOfProduct = _context.InStocks.FirstOrDefault(i => i.ProductId == order.ProductId);
            var product = _context.Products.FirstOrDefault(p => p.Id == order.ProductId);
            if (ModelState.IsValid)
            {
                if (order.Quantity > 0 && order.Quantity <= inStockOfProduct.UnitInStock)
                {
                    order.TotalPrice = order.Quantity * product.Price;
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                }
                else
                {
                    ViewBag.Error = "Số lượng sản phẩm không hợp lệ";
                }
                return RedirectToAction("Index");
            } 
            return RedirectToAction("Index");
        }   
    }
}
