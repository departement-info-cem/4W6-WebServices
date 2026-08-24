namespace Vincible.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public bool IsAlive { get; set; }
        public string Img { get; set; } = null!;
        public virtual List<Superpower> Superpowers { get; set; } = new List<Superpower>();
    }
}
