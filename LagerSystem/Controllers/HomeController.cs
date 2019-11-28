using LagerSystem.Data;
using LagerSystem.Models;
using LagerSystem.Models.StorageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StorageContext _context;

        public HomeController(ILogger<HomeController> logger, StorageContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index()
        {
            if (!_context.Storages.Any())
            {
                return RedirectToAction("Create", "Home");
            }
            //var test = from a in _context.Storages
            //           .Include(r => r.Racks)
            //           .ThenInclude(p => p.Positions)
            //           .ThenInclude(p => p.Pallet)
            //           select a;

            return View();

        }

        // GET: Storages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Storages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StorageName,StreetName,City,Postal,Telephone")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storage);
        }

        [HttpGet]
        [Route("api/item/{id}")]
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new PalletIndexData();
            viewModel.Pallets = await _context.Pallets
                    .Include(i => i.PalletItems)
                    .ThenInclude(i => i.StockItem)
                    .OrderBy(i => i.RackPosition)
                .ToListAsync();

            if (id != null)
            {

                Pallet pallet = viewModel.Pallets
                    .Where(i => i.Id == id.Value).Single();
                viewModel.StockItems = pallet.PalletItems.Select(i => i.StockItem);
            }
            return View(viewModel);
        }
        //[HttpGet]
        //[Route("api/pallet/{pal}")]
        //public IActionResult Pal(string pal)
        //{
        //    var test = _context.Pallets
        //        .Include(i => i.Items)
        //        .Where(p => p.RackPosition == pal);

        //    return Json(test);
        //}

        [HttpGet]
        [Route("api/pos/{pos}")]
        public IActionResult Position(string pos)
        {
            var test = _context.Positions
                .Where(p => p.RackPosition == pos);

            return Json(test);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
