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
            var te = 0;
            Positions = new List<Position>();
            for (int i = 1; i <= Width; i++)
            {
                for (int j = 1; j <= Height; j++)
                {
                    Positions.Add(new Position { Height = i, Width = j });
                }

            }
        }

        //public void generate(List<Rack> racks)
        //{
        //    Positions = new List<Position>();
        //    foreach (var rack in racks)
        //    {
        //        for (int i = 1; i <= rack.Width; i++)
        //        {
        //            for (int j = 1; j <= rack.Height; j++)
        //            {
        //                Positions.Add(new Position { Height = i, Width = j , RackId = rack.Id});
        //            }

        //        }
        //    }

        //    int v = 0;

        //}

    }
}
