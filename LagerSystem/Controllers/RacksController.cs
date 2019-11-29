using LagerSystem.Data;
using LagerSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Views
{
    public class RacksController : Controller
    {
        private readonly StorageContext _context;

        public RacksController(StorageContext context)
        {
            _context = context;
        }

        // GET: Racks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Racks.ToListAsync());
        }

        // GET: Racks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rack = await _context.Racks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rack == null)
            {
                return NotFound();
            }

            return View(rack);
        }

        // GET: Racks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Racks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Height,Width")] Rack rack)
        {
            var antal = _context.Racks
                .Count();

            if (ModelState.IsValid)
            {
                antal++;

                rack.Positions = new List<Position>();

                for (int i = 1; i <= rack.Width; i++)
                {
                    for (int j = 1; j <= rack.Height; j++)
                    {
                        rack.Positions.Add(new Position { Height = j, Width = i, RackPosition = antal.ToString() + i.ToString() + j.ToString() });
                    }

                }
                var storage = _context.Storages.FirstOrDefault();

                rack.StorageId = storage.Id;

                _context.AddRange(rack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rack);
        }

        // GET: Racks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rack = await _context.Racks.FindAsync(id);
            if (rack == null)
            {
                return NotFound();
            }
            return View(rack);
        }

        // POST: Racks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Height,Width")] Rack rack)
        {
            if (id != rack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RackExists(rack.Id))
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
            return View(rack);
        }

        // GET: Racks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //TODO Funktion til at sætte pallets rackposition til null
            var rack = await _context.Racks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rack == null)
            {
                return NotFound();
            }

            return View(rack);
        }

        // POST: Racks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rack = await _context.Racks.FindAsync(id);
            _context.Racks.Remove(rack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RackExists(int id)
        {
            return _context.Racks.Any(e => e.Id == id);
        }

    }
}
