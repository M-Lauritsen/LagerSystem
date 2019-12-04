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
            var viewModel = new PalletIndexData();
            viewModel.Pallets = await _context.Pallets
                .Include(i => i.PalletItems)
                .ThenInclude(i => i.StockItem)
                .ToListAsync();

            if (id != null)
            {
                ViewData["StockItemsId"] = id.Value;
                Pallet pall = viewModel.Pallets
                    .Where(i => i.Id == id.Value).Single();
                viewModel.StockItems = pall.PalletItems.Select(i => i.StockItem);
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
            viewModel.StockItems = _context.StockItems;

            ViewBag.data = viewModel;

            return View(viewModel);
        }

        // POST: Pallets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RackPosition")] PalletItemsViewModel palletItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Pallet());
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(palletItem.Pallet);
        }

        // GET: Pallets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PalletItemsViewModel pallet = new PalletItemsViewModel();
            pallet.Pallet = await _context.Pallets
                .Include(s => s.PalletItems)
                .ThenInclude(s => s.StockItem)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (pallet == null)
            {
                return NotFound();
            }
            //test.Pallet = pallet;
            return View(pallet);
        }

        // POST: Pallets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Pallet,StockItem")] PalletItemsViewModel palletItems)
        //{
        //    if (id != palletItems.Pallet.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(palletItems.Pallet);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PalletExists(palletItems.Pallet.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(palletItems.Pallet);
        //}

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Pallet pallet, [Bind("Id,Pallet,StockItem")] PalletItemsViewModel vm)
        {
            var id = _context.StockItems.Where(i => i.Name == vm.StockItem.Name).Select(i => i.Id).FirstOrDefault();

            if (pallet.Id != vm.Pallet.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var item = new PalletItems
                    {
                        StockItemId = id,
                        PalletId = vm.Pallet.Id,
                    };

                    _context.PalletItems.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalletExists(vm.Pallet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }


            return View(vm);
        }

        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.PalletItems
                .Include(p => p.StockItem)
                .FirstOrDefaultAsync(m => m.StockItemId == id);


            _context.PalletItems.Remove(position);
            await _context.SaveChangesAsync();
            if (position == null)
            {
                return NotFound();
            }

            return RedirectToAction("Edit", new { @id = position.PalletId });
        }



        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }

    }
}
