using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.Models.StorageViewModel
{
    public class PalletIndexData
    {
        public IEnumerable<Pallet> Pallets { get; set; }
        public IEnumerable<StockItem> StockItems { get; set; }
    }
}
