using System.Text.Json.Serialization;

namespace TP2_serveur.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        [JsonIgnore]
        public virtual Artist Artist { get; set; } = null!;

        [JsonIgnore]
        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}
