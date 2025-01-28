using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eventify.Models;

namespace Eventify.Controllers
{
    public class Events1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Events1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events1
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Events.ToListAsync());
        //}

        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 10)
        {
            // Start with the full query
            var query = _context.Events.AsQueryable();

            // Filter by name if searchString is provided
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.EventName.Contains(searchString));
            }

            // Calculate total events and total pages
            int totalEvents = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalEvents / pageSize);

            // Pass pagination data using ViewData
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;
            ViewData["SearchString"] = searchString;

            // Fetch the paginated and filtered events
            var events = await query
                .OrderBy(e => e.EventsId) // Optional: Order by ID or another field
                .Skip((page - 1) * pageSize) // Skip previous pages
                .Take(pageSize) // Take only the page size
                .ToListAsync();

            return View(events); // Return the list of events
        }


        // GET: Events1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .FirstOrDefaultAsync(m => m.EventsId == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: Events1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventsId,EventName,StartDate,EndDate,Location")] Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        // GET: Events1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: Events1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventsId,EventName,StartDate,EndDate,Location")] Events events)
        {
            if (id != events.EventsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsExists(events.EventsId))
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
            return View(events);
        }

        // GET: Events1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .FirstOrDefaultAsync(m => m.EventsId == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // POST: Events1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Events.FindAsync(id);
            if (events != null)
            {
                _context.Events.Remove(events);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventsExists(int id)
        {
            return _context.Events.Any(e => e.EventsId == id);
        }
    }
}
