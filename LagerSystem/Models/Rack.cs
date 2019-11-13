using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Rack
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public IEnumerable<Position> Positions { get; set; }
    }
}
