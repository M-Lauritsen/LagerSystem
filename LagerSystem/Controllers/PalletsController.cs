using LagerSystem.Data;
using LagerSystem.Models;
using LagerSystem.Models.StorageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Views
{
    public class PalletsController : Controller
    {
        private readonly StorageContext _context;

        public PalletsController(StorageContext context)
        {
            _context = context;
        }

        // GET: Pallets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pallets.ToListAsync());
        }

        // GET: Pallets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pallet = await _context.Pallets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pallet == null)
            {
                return NotFound();
            }

            return View(pallet);
        }

        // GET: Pallets/Create
        public IActionResult Create()
        {
            PalletItemsViewModel viewModel = new PalletItemsViewModel();
            viewModel.StockItem = _context.StockItems;

            ViewBag.data = viewModel;

            return View(viewModel);
        }

        // POST: Pallets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RackPosition")] Pallet pallet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pallet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pallet);
        }

        // GET: Pallets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pallet = await _context.Pallets.FindAsync(id);
            if (pallet == null)
            {
                return NotFound();
            }
            return View(pallet);
        }

        // POST: Pallets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RackPosition")] Pallet pallet)
        {
            if (id != pallet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pallet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalletExists(pallet.Id))
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
            return View(pallet);
        }

        // GET: Pallets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pallet = await _context.Pallets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pallet == null)
            {
                return NotFound();
            }

            return View(pallet);
        }

        // POST: Pallets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pallet = await _context.Pallets.FindAsync(id);
            _context.Pallets.Remove(pallet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PalletExists(int id)
        {
            return _context.Pallets.Any(e => e.Id == id);
        }

        
    }
}
