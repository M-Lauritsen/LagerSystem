using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LagerSystem.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        
        [Display(Name = "Products")]
        public string Name { get; set; }
        public int Amount { get; set; }
        public ICollection<PalletItems> PalletItems { get; set; }
    }
}
