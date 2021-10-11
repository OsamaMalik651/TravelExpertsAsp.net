//Date: October 11, 2021
//Projetct: PROJ-009-003 – Project Workshop 4, Travel Experts Website

//Group 1, Team 1:
//Osama Malik		SAIT Student ID 880863
//Tracy Crape		SAIT Student ID 420488
//Adesola Oyatunji	SAIT Student ID 838997

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_Experts__Workshop_4.Areas.Identity.Data;
using Travel_Experts__Workshop_4.Domain;

namespace Travel_Experts__Workshop_4.Controllers
{   
    [Authorize]
    public class BookingsController : Controller
    {
        private Microsoft.AspNetCore.Identity.UserManager<Travel_Experts__Workshop_4User> userManager;
    
        private readonly TravelExperts_Context _context;

        public BookingsController(Microsoft.AspNetCore.Identity.UserManager<Travel_Experts__Workshop_4User> usrMgr, TravelExperts_Context context)
        {
            _context = context;
            userManager = usrMgr;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var travelExperts_Context = _context.Bookings.Include(b => b.Customer).Include(b => b.Package).Include(b => b.TripType);
            return View(await travelExperts_Context.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Package)
                .Include(b => b.TripType)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create(int id)
        {
            var userId = User.Identity.GetUserId();
            HttpContext.Session.SetString("CurrentUser", userId);
            var currentUserId = HttpContext.Session.GetString("CurrentUser");
            var currentUser = userManager.FindByIdAsync(currentUserId).Result;
            var customers = CustomerManager.GetCustomers();
            Customer customer = customers.Find(i => i.CustEmail == currentUser.Email);


            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustFullName");
            ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName");
            ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId");
            var Package = _context.Packages.Find(id);
            TempData["SelectedPackage"] = Package;
            TempData["CurrentCustomer"] = customer;
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,BookingDate,BookingNo,TravelerCount,CustomerId,TripTypeId,PackageId")] Booking booking)
        {
            var Package = _context.Packages.Find(booking.PackageId);
            Random r = new Random();
            int num = r.Next(1000, 9999);
            if (ModelState.IsValid)
            {
                booking.BookingNo = $"ABCD{num}";
                _context.Add(booking);
                await _context.SaveChangesAsync();
                var bookingDetail = new BookingDetail
                {  
                    BookingId = booking.BookingId,
                    ItineraryNo = null,
                    TripStart = Package.PkgStartDate,
                    TripEnd = Package.PkgEndDate,
                    Description = Package.PkgDesc,
                    Destination = null,
                    BasePrice = Package.PkgBasePrice * Convert.ToDecimal(booking.TravelerCount),
                    AgencyCommission = Package.PkgAgencyCommission * Convert.ToDecimal(booking.TravelerCount),
                    RegionId = null,
                    ClassId = null,
                    FeeId = null,
                    ProductSupplierId = null

                };
                _context.BookingDetails.Add(bookingDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "User");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustAddress", booking.CustomerId);
            ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName", booking.PackageId);
            ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId", booking.TripTypeId);
            return RedirectToAction("Index", "User");
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustAddress", booking.CustomerId);
            ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName", booking.PackageId);
            ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId", booking.TripTypeId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,BookingDate,BookingNo,TravelerCount,CustomerId,TripTypeId,PackageId")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Package = _context.Packages.Find(booking.PackageId);
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                                        var bookingDetail = new BookingDetail
                                        {
                                            BookingId = booking.BookingId,
                                            ItineraryNo = null,
                                            TripStart = Package.PkgStartDate,
                                            TripEnd = Package.PkgEndDate,
                                            Description = Package.PkgDesc,
                                            Destination = null,
                                            BasePrice = Package.PkgBasePrice * Convert.ToDecimal(booking.TravelerCount),
                                            AgencyCommission = Package.PkgAgencyCommission * Convert.ToDecimal(booking.TravelerCount),
                                            RegionId = null,
                                            ClassId = null,
                                            FeeId = null,
                                            ProductSupplierId = null

                                        };
                                        
                                     
                    var bookingDetailsEntry = _context.BookingDetails.Where(i => i.BookingId == booking.BookingId).FirstOrDefault();
                    bookingDetail.BookingDetailId = bookingDetailsEntry.BookingDetailId;
                    _context.Entry(bookingDetailsEntry).CurrentValues.SetValues(bookingDetail);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "User");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "User");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustAddress", booking.CustomerId);
            ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName", booking.PackageId);
            ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId", booking.TripTypeId);
            return RedirectToAction("Index", "User");
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Package)
                .Include(b => b.TripType)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            var bookingDetails = _context.BookingDetails.Where(i => i.BookingId == booking.BookingId).FirstOrDefault();
            _context.BookingDetails.Remove(bookingDetails);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "User");
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
