namespace LagerSystem.Models
{
    public class Position
    {
        public int Id { get; set; }
        public bool Available { get; set; } = true;
        public Pallet Pallet { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
