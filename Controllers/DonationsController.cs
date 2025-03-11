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
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)

        {
            _context = context;
        }

        // GET: Donations
        public async Task<IActionResult>  Index(string searchString) //ADDED THIS > Index(string searchString) - new
        {

            // ViewData["Title"] = "Donations";: This line is used to set the page title to "Donations" for this view, which will be displayed at the top of the webpage.
            ViewData["Title"] = "Donations";  // Set the page title for Donations index - ADDED

            //ADDED CODE BELOW 
            // This line fetches all donations from the database. The code doesn't filter donations at this point.
            //var donations = from d in _context.Donation
            //                select d;

            var donations = _context.Donation.Include(d => d.User); // Load related User data - MODIFIED


            // If search string is provided, filter donations by Name. - ADDED
            //  This part checks if a search string has been entered by the user. If it is not empty, it filters the donations by the Name field (the name of the donor). It searches donations that contain the entered search string in their name.
            if (!string.IsNullOrEmpty(searchString))
            {
                donations = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Donation, User?>)donations.Where(d => d.Name.Contains(searchString)); // Filter by donor name
            }

            // This stores the search string in the ViewData so that it can be displayed on the webpage. This is useful for showing the user the text they searched for.
            ViewData["SearchString"] = searchString;  // Pass searchString to the View


            return View(await _context.Donation.ToListAsync());
        }

        // GET: Donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Load the related User data using Include
            var donation = await _context.Donation

               // This line includes the related User data - ADDED
               // This line ensures that for each donation, the corresponding user information is automatically loaded with it.
               .Include(d => d.User)  // This line includes the related User data - ADDED
               .FirstOrDefaultAsync(m => m.DonationID == id);

            if (donation == null)
            {
                return NotFound();
            }

            // Set the page title for Donation details - ADDED
            // This line simply sets the title of the page to "Donation Details" when the user is viewing the details of a donation.
            ViewData["Title"] = "Donation Details";  
            return View(donation);
        }

        // GET: Donations/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Donation";  // Set the page title for Create donation page - MODIFIED - 3added
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Name"); // Populate User dropdown - 3ADDED
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationID,Name,Amount,DateTime,UserID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Name", donation.UserID);
            ViewData["Title"] = "Create Donation";  // Set the page title for Create donation page - ADDED
            return View(donation);
        }

        // GET: Donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donation //modified 3added
                .Include(d => d.User) // ✅ Load related User data 3added
                .FirstOrDefaultAsync(m => m.DonationID == id); //3added

            if (donation == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Edit Donation";  // Set the page title for Edit donation page - ADDED
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonationID,Name,Amount,DateTime,UserID")] Donation donation)
        {
            if (id != donation.DonationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    // 3added
                    var existingDonation = await _context.Donation
                        .Include(d => d.User) // ✅ Ensure related User data is included
                        .FirstOrDefaultAsync(d => d.DonationID == id);

                    if (existingDonation == null)
                    {
                        return NotFound();
                    }

                    _context.Entry(existingDonation).CurrentValues.SetValues(donation);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationExists(donation.DonationID))
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
            ViewData["Title"] = "Edit Donation";  // Set the page title for Edit donation page - ADDED
            return View(donation);
        }

        // GET: Donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donation //3added
                .Include(d => d.User)  // Load related User data - MODIFIED 3added
                .FirstOrDefaultAsync(m => m.DonationID == id); //3added

            if (donation == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Delete Donation";  // Set the page title for Delete donation page - ADDED
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //3added start
            var donation = await _context.Donation
                .Include(d => d.User) // ✅ Load related User data
                .FirstOrDefaultAsync(m => m.DonationID == id);

            if (donation == null)
            {
                return NotFound();
            }

            _context.Donation.Remove(donation);
            await _context.SaveChangesAsync();
            //3added end

            return RedirectToAction(nameof(Index));
        }

        private bool DonationExists(int id)
        {
            return _context.Donation.Any(e => e.DonationID == id);
        }
    }
}