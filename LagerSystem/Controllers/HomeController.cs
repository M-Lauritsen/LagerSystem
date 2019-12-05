using LagerSystem.Data;
using LagerSystem.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        // GET: Storages/Create
        public IActionResult Create()
        {
            return View();
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
