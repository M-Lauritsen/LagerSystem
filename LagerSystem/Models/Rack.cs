using System.Collections.Generic;

namespace LagerSystem.Models
{
    public class Rack
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Position> Positions { get; set; }

        public Rack()
        {
            var test = 0;
            Positions = new List<Position>();

            for (int i = 1; i <= Width; i++)
            {
                for (int j = 1; j <= Height; j++)
                {
                    Positions.Add(new Position { Width = i, Height = j });
                }
            }
        }

    }
}
