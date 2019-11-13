using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string StorageName { get; set; }

        public int Total { get; set; }

        public int NumberOfRacks { get; set; }
        public List<Rack> Racks { get; set; }

        public List<Pallet> Pallets { get; set; }

    }
}
