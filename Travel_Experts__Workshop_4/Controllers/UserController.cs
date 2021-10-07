using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Experts__Workshop_4.Areas.Identity.Data;
using Travel_Experts__Workshop_4.Data;
using Travel_Experts__Workshop_4.Domain;
using Travel_Experts__Workshop_4.Models;

namespace Travel_Experts__Workshop_4.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private Microsoft.AspNetCore.Identity.UserManager<Travel_Experts__Workshop_4User> userManager;
        private TravelExperts_Context context { get; set; }
        public UserController(Microsoft.AspNetCore.Identity.UserManager<Travel_Experts__Workshop_4User> usrMgr, TravelExperts_Context _context)
        {
            userManager = usrMgr;
            context = _context;
        }
        // GET: UserController
        public ActionResult Index()
        {   var userId = User.Identity.GetUserId();
            HttpContext.Session.SetString("CurrentUser", userId );
            var currentUserId = HttpContext.Session.GetString("CurrentUser");
            var currentUser = userManager.FindByIdAsync(currentUserId).Result;
            var customers = CustomerManager.GetCustomers();
            Customer customer = customers.Find(i=> i.CustEmail == currentUser.Email);

            var model = new CustomerViewModel
            {
                Customer = customers.Find(i => i.CustEmail == currentUser.Email),
                Bookings = context.Bookings.Include(b => b.BookingDetails)
                                            .Where(b => b.CustomerId == customer.CustomerId).ToList(),
               //d BookingDetails = context.BookingDetails.ToList()
            };
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            /*Customer customer = CustomerManager.Find(id);*/
            return RedirectToAction("Edit", "Customers", id);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
