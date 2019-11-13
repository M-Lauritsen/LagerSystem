using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string StorageName { get; set; }

        public int Total { get; set; }

        public int NumberOfRacks { get; set; }
        public IEnumerable<Rack> Racks { get; set; }

        public IEnumerable<Pallet> Pallets { get; set; }
    }
}
