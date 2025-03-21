﻿using System;
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
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Vehicles
        public async Task<IActionResult> Index(string searchString) //ADDED THIS > Index(string searchString) - new
        {
            ViewData["Title"] = "Vehicle";  // Set the page title for Donations index - ADDED

            //ADDED CODE BELOW - new
            var vehicle = from d in _context.Donation
                            select d;

            // If search string is provided, filter donations by Name. - ADDED
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicle = vehicle.Where(d => d.Name.Contains(searchString)); // Filter by donor name
            }

            ViewData["SearchString"] = searchString;  // Pass searchString to the View

            return View(await _context.Vehicle.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.VehicleID == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Vehicle";  // Set the page title for Donations index - ADDED
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Vehicle";  // Set the page title for Donations index - ADDED
            ViewData["DriverID"] = new SelectList(_context.Driver, "DriverID", "UserID"); // Populate Driver dropdown - ADDED

            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleID,DriverID,LicensePlate,Brand,Model,Capacity")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DriverID"] = new SelectList(_context.Driver, "DriverID", "UserID", vehicle.DriverID);
            ViewData["Title"] = "Vehicle";  // Set the page title for Donations index - ADDED
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Vehicle";  // Set the page title for Donations index - ADDED
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleID,DriverID,LicensePlate,Brand,Model,Capacity")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleID))
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
            ViewData["Title"] = "Vehicle";  // Set the page title for Donations index - ADDED
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.VehicleID == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Vehicle";  // Set the page title for Donations index - ADDED
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.VehicleID == id);
        }
    }
}
