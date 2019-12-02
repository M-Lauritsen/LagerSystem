﻿using LagerSystem.Data;
using LagerSystem.Models;
using LagerSystem.Models.StorageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> ItemId(int? id)
        {
            var viewModel = new PalletIndexData
            {
                Pallets = await _context.Pallets
                    .Include(i => i.PalletItems)
                    .ThenInclude(i => i.StockItem)
                    .OrderBy(i => i.RackPosition)
                .ToListAsync()
            };

            if (id != null)
            {

                Pallet pallet = viewModel.Pallets
                    .Where(i => i.Id == id.Value).Single();
                viewModel.StockItems = pallet.PalletItems.Select(i => i.StockItem);
            }
            return Ok(viewModel);
        }

        //[HttpGet("{pal")]
        //public IActionResult Pal(string pal)
        //{
        //    var test = _context.Pallets
        //        .Include(i => i.Items)
        //        .Where(p => p.RackPosition == pal);

        //    return Json(test);
        //}
    }



}