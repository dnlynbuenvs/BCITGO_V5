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
    public class TripPostingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripPostingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TripPostings
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "TripPosting";  // Set the page title for Donations index - ADDED
            return View(await _context.TripPosting.ToListAsync());
        }

        // GET: TripPostings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripPosting = await _context.TripPosting
                .FirstOrDefaultAsync(m => m.TripPostingID == id);
            if (tripPosting == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "TripPosting";  // Set the page title for Donations index - ADDED
            return View(tripPosting);
        }

        // GET: TripPostings/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "TripPosting";  // Set the page title for Donations index - ADDED
            return View();
        }

        // POST: TripPostings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripPostingID,DriverID,VehicleID,StartLocation,EndLocation,Date,SeatAvailable,Status")] TripPosting tripPosting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripPosting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Title"] = "TripPosting";  // Set the page title for Donations index - ADDED
            return View(tripPosting);
        }

        // GET: TripPostings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripPosting = await _context.TripPosting.FindAsync(id);
            if (tripPosting == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "TripPosting";  // Set the page title for Donations index - ADDED
            return View(tripPosting);
        }

        // POST: TripPostings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripPostingID,DriverID,VehicleID,StartLocation,EndLocation,Date,SeatAvailable,Status")] TripPosting tripPosting)
        {
            if (id != tripPosting.TripPostingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripPosting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripPostingExists(tripPosting.TripPostingID))
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
            ViewData["Title"] = "TripPosting";  // Set the page title for Donations index - ADDED
            return View(tripPosting);
        }

        // GET: TripPostings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripPosting = await _context.TripPosting
                .FirstOrDefaultAsync(m => m.TripPostingID == id);
            if (tripPosting == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "TripPosting";  // Set the page title for Donations index - ADDED
            return View(tripPosting);
        }

        // POST: TripPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripPosting = await _context.TripPosting.FindAsync(id);
            if (tripPosting != null)
            {
                _context.TripPosting.Remove(tripPosting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripPostingExists(int id)
        {
            return _context.TripPosting.Any(e => e.TripPostingID == id);
        }
    }
}
