using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Rack
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Position> Positions { get; set; }

        public int StorageId { get; set; }
        public Storage Storage { get; set; }

    }
}
