using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Pallet
    {
        public int Id { get; set; }

        public string RackPosition { get; set; }
        public Position Position { get; set; }

        public ICollection<PalletItems> PalletItems { get; set; }

    }
}
