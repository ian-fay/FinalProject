using System;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Linq;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private NorthwindContext _northwindContext;
        public ProductController(NorthwindContext db) => _northwindContext = db;
        public ActionResult Discounts()
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                if (User.IsInRole("northwind-employee")){
                    return View(_northwindContext.Discounts);
                }
            }
            return View(_northwindContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
        }

        public IActionResult Category() => View(_northwindContext.Categories.OrderBy(c => c.CategoryName));
        public IActionResult Index(int id){
            ViewBag.id = id;
            return View(_northwindContext.Categories.OrderBy(c => c.CategoryName));
        }
    }
}
