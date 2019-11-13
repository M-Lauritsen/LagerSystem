using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Pallet
    {
        public int Id { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
