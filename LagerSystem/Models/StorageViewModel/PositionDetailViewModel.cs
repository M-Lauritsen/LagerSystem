using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Models.StorageViewModel
{
    public class PositionDetailViewModel
    {
        public Position Position { get; set; }
        public Pallet Pallet { get; set; }
        public StockItem StockItem { get; set; }
    }
}
