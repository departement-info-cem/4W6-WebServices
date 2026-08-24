namespace Vincible.Models.DTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public bool IsAlive { get; set; }
        public string ImageUrl { get; set; } = null!;
        public List<string> Superpowers { get; set; } = new List<string>();

        public CharacterDTO(Character c)
        {
            Id = c.Id;
            Name = c.Name;
            Age = c.Age;
            IsAlive = c.IsAlive;
            ImageUrl = "http://localhost:5254/api/Characters/GetPicture/" + c.Id;
            Superpowers = c.Superpowers.Select(s => s.Name).ToList();
        }
    }
}
