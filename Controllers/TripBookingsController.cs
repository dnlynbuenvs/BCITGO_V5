using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BCITGO_FINAL.Data;
using BCITGO_FINAL.Models;

namespace BCITGO_FINAL.Controllers
{
    public class TripBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: TripBookings
        public async Task<IActionResult> Index(string searchString) //ADDED THIS > Index(string searchString) - new
        {
            ViewData["Title"] = "TripBookings";  // Set the page title for Donations index - ADDED

            //ADDED CODE BELOW - new
            var TripBooking = from tb in _context.TripBooking
                               .Include(tb => tb.TripPosting) // Load related TripPosting data
                               .Include(tb => tb.User) // Load related User data
                              select tb;


            // If search string is provided, filter donations by Name. - ADDED
            if (!string.IsNullOrEmpty(searchString))
            {
                TripBooking = TripBooking
                    .Where(tb => tb.User.Name.Contains(searchString) ||
                                 tb.TripPostingID.ToString().Contains(searchString)); // ✅ Search by User Name or TripPostingID
            }



            ViewData["SearchString"] = searchString;  // Pass searchString to the View


            return View(await _context.TripBooking.ToListAsync());
        }

        // GET: TripBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripBooking = await _context.TripBooking
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (tripBooking == null)
            {

                return NotFound();
            }
            ViewData["Title"] = "TripBookings";  // Set the page title for Donations index - ADDED
            return View(tripBooking);
        }

        // GET: TripBookings/Create
        public IActionResult Create()
        {

            ViewData["Title"] = "Create Trip Posting";  // Set the page title - ADDED
            ViewData["TripPostingID"] = new SelectList(_context.TripPosting, "TripPostingID", "StartLocation");
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Name");
            return View();
        }

        // POST: TripBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,TripPostingID,UserID,SeatsBook,BookingStatus")] TripBooking tripBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TripPostingID"] = new SelectList(_context.TripPosting, "TripPostingID", "TripPostingID", tripBooking.TripPostingID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Name", tripBooking.UserID);
            ViewData["TripPostingID"] = new SelectList(_context.TripPosting, "TripPostingID", "TripPostingID", tripBooking.TripPostingID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Name", tripBooking.UserID);


            ViewData["Title"] = "Create Trip Posting";  // Set the page title - ADDED
            return View(tripBooking);
        }

        // GET: TripBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripBooking = await _context.TripBooking.FindAsync(id);
            if (tripBooking == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "TripBookings";  // Set the page title for Donations index - ADDED
            return View(tripBooking);
        }

        // POST: TripBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,TripPostingID,UserID,SeatsBook,BookingStatus")] TripBooking tripBooking)
        {
            if (id != tripBooking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripBookingExists(tripBooking.BookingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Title"] = "TripBookings";  // Set the page title for Donations index - ADDED
            return View(tripBooking);
        }

        // GET: TripBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripBooking = await _context.TripBooking
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (tripBooking == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "TripBookings";  // Set the page title for Donations index - ADDED
            return View(tripBooking);
        }

        // POST: TripBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripBooking = await _context.TripBooking.FindAsync(id);
            if (tripBooking != null)
            {
                _context.TripBooking.Remove(tripBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripBookingExists(int id)
        {
            return _context.TripBooking.Any(e => e.BookingID == id);
        }
    }
}
