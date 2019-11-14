using LagerSystem.Data;
using LagerSystem.Models;
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

            var test = from a in _context.Storages
                       .Include(r => r.Racks)
                       .ThenInclude(p => p.Positions)
                       .ThenInclude(p => p.Pallet)
                       select a;


            return Json(test);
        }

        [HttpGet]
        [Route("api/item/{name}")]
        public IActionResult Index(string name)
        {
            var test = _context.Items
                .Where(p => p.Name == name);

            return Json(test);
        }
        [HttpGet]
        [Route("api/pallet/{pal}")]
        public IActionResult Index(int pal)
        {
            var test = _context.Positions
                .Where(p => p.PalletId == pal);

            return Json(test);
        }

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
