using System.Collections.Generic;

namespace LagerSystem.Models.StorageViewModel
{
    public class PalletItemsViewModel
    {
        public Pallet Pallet { get; set; }
        public IEnumerable<StockItem> StockItem { get; set; }
    }
}
