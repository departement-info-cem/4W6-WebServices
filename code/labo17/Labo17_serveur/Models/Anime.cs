using System.Text.Json.Serialization;

namespace Labo17_serveur.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string> Genres { get; set; } = new List<string>();

        public string? ImageUrl { get; set; }


    }
}
