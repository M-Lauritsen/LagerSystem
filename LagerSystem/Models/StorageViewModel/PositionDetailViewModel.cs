using System.Collections;
using System.Collections.Generic;

namespace LagerSystem.Models.StorageViewModel
{
    public class PositionDetailViewModel
    {
        public Position Position { get; set; }
        public Pallet Pallet { get; set; }
        public StockItem StockItem { get; set; }
        public IEnumerable<Position> Positions{ get; set; }
    }
}
