using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int NumberOfRacks { get; set; }
        public IEnumerable<Rack> Racks { get; set; }
    }
}
