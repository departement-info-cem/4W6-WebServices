using System.Text.Json.Serialization;

namespace TP2_serveur.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        [JsonIgnore]
        public virtual List<Album> Albums { get; set; } = new List<Album>();
    }
}
