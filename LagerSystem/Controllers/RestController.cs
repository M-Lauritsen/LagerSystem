using LagerSystem.Data;
using LagerSystem.Models;
using LagerSystem.Models.StorageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/item")]
    public class RestController : Controller
    {
        private readonly StorageContext _context;

        public RestController(StorageContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public IActionResult Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = _context.StockItems.Where(s => s.Name.Contains(term)).Select(s => s.Name).ToList();

                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("searchpallet")]
        public IActionResult Searchpallet()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = _context.Positions
                    .Include(p => p.Pallet)
                        .ThenInclude(i => i.PalletItems)
                            .ThenInclude(s => s.StockItem)
                    .Where(s => s.Id == Convert.ToInt32(term)).Select(s => s.Pallet.PalletItems);

                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
