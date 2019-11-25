using LagerSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.Controllers
{
    [Route("api/item")]
    public class StockItemRestController : Controller
    {
        private readonly StorageContext _context;

        public StockItemRestController(StorageContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
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
    }
}
