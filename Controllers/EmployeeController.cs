using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Northwind.Controllers
{
    public class EmployeeController : Controller
    {
        // this controller depends on the NorthwindRepository
        private NorthwindContext _northwindContext;
        private UserManager<AppUser> _userManager;

        public EmployeeController(NorthwindContext db, UserManager<AppUser> usrMgr)
        {
            _northwindContext = db;
            _userManager = usrMgr;
        }

        [Authorize(Roles = "northwind-employee")]
        public IActionResult AddDiscount() 
        {
            ViewBag.Products = _northwindContext.Products.OrderBy(p => p.ProductName);
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "northwind-employee")]
        public IActionResult AddDiscount(Discount discount)
        {
            if (ModelState.IsValid)
            {
                if (_northwindContext.Discounts.Any(d => d.Code == discount.Code))
                {
                    ModelState.AddModelError("", "Discount code must be unique");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        // Create discount (Northwind)
                        _northwindContext.AddDiscount(discount);
                        return RedirectToAction("Discounts", "Product");
                    }
                }
            }
            // return RedirectToAction("AddDiscount", "Employee");
            ViewBag.Products = _northwindContext.Products.OrderBy(p => p.ProductName);
            return View();
        }

        [Authorize(Roles = "northwind-employee")]
        public IActionResult RemoveDiscount(int id) {
            _northwindContext.RemoveDiscount(_northwindContext.Discounts.FirstOrDefault(d => d.DiscountId == id));
            return RedirectToAction("Discounts", "Product");
        }

        [Authorize(Roles = "northwind-employee")]
        public IActionResult EditDiscount(int id) 
        {
            ViewBag.Products = _northwindContext.Products.OrderBy(p => p.ProductName);
            return View(_northwindContext.Discounts.FirstOrDefault(d => d.DiscountId == id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "northwind-employee")]
        public IActionResult EditDiscount(Discount discount)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    // Create discount (Northwind)
                    _northwindContext.EditDiscount(discount);
                    return RedirectToAction("Discounts", "Product");
                }
            }
            ViewBag.Products = _northwindContext.Products.OrderBy(p => p.ProductName);
            return View(_northwindContext.Discounts.FirstOrDefault(d => d.DiscountId == discount.DiscountId));
        }
    }
}