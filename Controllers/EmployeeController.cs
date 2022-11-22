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
            return View();
        }

    }
}