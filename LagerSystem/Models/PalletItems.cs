using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Models
{
    public class PalletItems
    {
        public int PalletId { get; set; }
        public Pallet Pallet { get; set; }

        public int StockItemId { get; set; }
        public StockItem StockItem { get; set; }

        public int Amount { get; set; }
    }
}
