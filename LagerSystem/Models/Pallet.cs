using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Pallet
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public List<Item> Items { get; set; }
    }
}
