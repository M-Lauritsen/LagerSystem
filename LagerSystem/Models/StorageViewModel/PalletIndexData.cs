using System.Collections.Generic;

namespace LagerSystem.Models.StorageViewModel
{
    public class PalletIndexData
    {
        public IEnumerable<Pallet> Pallets { get; set; }
        public IEnumerable<StockItem> StockItems { get; set; }
    }
}
