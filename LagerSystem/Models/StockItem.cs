using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public ICollection<PalletItems> PalletItems { get; set; }
    }
}
