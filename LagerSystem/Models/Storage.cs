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

        public void Generate()
        {
            foreach (var item in Racks)
            {
                item.Positions = new List<Position>();

                for (int i = 1; i <= item.Width; i++)
                {
                    for (int j = 1; j <= item.Height; j++)
                    {
                        item.Positions.Add(new Position { Height = j, Width = i });
                    }

                }
            }
        }
    }
}
