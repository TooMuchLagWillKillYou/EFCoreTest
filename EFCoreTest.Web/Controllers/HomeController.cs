//using EFCoreTest.Common.Entities;
using EFCoreTest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EFCoreTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdventureWorksDBContext _context;

        public HomeController(AdventureWorksDBContext context)
        { 
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();

            return View(customers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}