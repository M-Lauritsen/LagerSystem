using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Models.StorageViewModel
{
    public class StorageStockitemViewModel
    {
        public Storage Storage { get; set; }
        public StockItem Stockitem { get; set; }
        public Pallet Pallet { get; set; }
        
    }
}
