using LagerSystem.Data;
using LagerSystem.Models;
using LagerSystem.Models.StorageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Views
{
    public class PositionsController : Controller
    {
        private readonly StorageContext _context;

        public PositionsController(StorageContext context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index(int id)
        {
            var positions = _context.Positions.Include(p => p.Pallet).OrderBy(r => r.RackPosition).Where(i => i.RackId == id);
            return View(await positions.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            PositionDetailViewModel position = new PositionDetailViewModel();
            if (id == null)
            {
                return NotFound();
            }
            position.Position = await _context.Positions
                .Include(p => p.Pallet)
                .ThenInclude(pi => pi.PalletItems)
                        .ThenInclude(s => s.StockItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            ViewData["PalletId"] = new SelectList(_context.Pallets, "Id", "Id");
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Available,PalletId,Height,Width,RackPosition")] Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PalletId"] = new SelectList(_context.Pallets, "Id", "Id", position.PalletId);
            return View(position);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PositionDetailViewModel position = new PositionDetailViewModel();

            position.Position = await _context.Positions
                .Include(p => p.Pallet)
                .ThenInclude(pi => pi.PalletItems)
                        .ThenInclude(s => s.StockItem)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (position == null)
            {
                return NotFound();
            }
            ViewData["PalletId"] = new SelectList(_context.Pallets, "Id", "Id", position.Position.PalletId);
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Position,Pallet,")] PositionDetailViewModel vm)
        {
            if (id != vm.Position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.Position.Available = false;
                    vm.Position.PalletId = vm.Pallet.Id;
                    vm.Pallet.RackPosition = vm.Position.RackPosition;

                    _context.Update(vm.Position);
                    _context.Update(vm.Pallet);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(vm.Position.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Positions", new { id = vm.Position.RackId });
            }
            ViewData["PalletId"] = new SelectList(_context.Pallets, "Id", "Id", vm.Position.PalletId);
            return View(vm.Position);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.Pallet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }


        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }

        public async Task<IActionResult> RemovePallet(int? id, Position pos)
        {
            if (id == null)
            {
                return NotFound();
            }

            pos = await _context.Positions
                .Include(p => p.Pallet)
                .FirstOrDefaultAsync(m => m.Id == id);

            pos.PalletId = null;
            pos.Available = true;

            pos.Pallet.RackPosition = null;

            _context.Update(pos);
            _context.SaveChanges();
            

            if (pos == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index","Positions",new { id = pos.RackId });
        }
    }
}
