using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LagerSystem.Models
{
    public class Rack
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Position> Positions { get; set; }

    }
}
