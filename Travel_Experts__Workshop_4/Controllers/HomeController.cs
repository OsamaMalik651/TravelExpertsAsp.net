using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Travel_Experts__Workshop_4.Domain;
using Travel_Experts__Workshop_4.Models;

namespace Travel_Experts__Workshop_4.Controllers
{
    public class HomeController : Controller
    {
        private TravelExperts_Context _context { get; set; }

       public HomeController(TravelExperts_Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "";
            var model = new HomeViewModel
            {
                Packages = _context.Packages.ToList(),
                Agency = _context.Agencies.ToList(),
                Agents = _context.Agents.ToList()
            };
            return View(model);
        }

        private dynamic GetAgnency()
        {
            throw new NotImplementedException();
        }

        private dynamic GetAgent()
        {
            throw new NotImplementedException();
        }

        //private readonly ILogger<HomeController> _logger;
        //private readonly TravelExperts_Context _context;

     /*   public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

 
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetContactPage()
        {
            var model = new HomeViewModel
            {
                Packages = _context.Packages.ToList(),
                Agency = _context.Agencies.ToList(),
                Agents = _context.Agents.ToList()
            };
            return View("ContactUs", model);
        }
        public IActionResult PackageDetailPage(int id)
        {
        
            var package = _context.Packages.FirstOrDefault(p => p.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
