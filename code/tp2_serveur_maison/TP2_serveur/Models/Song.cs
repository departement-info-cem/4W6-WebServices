using System.Text.Json.Serialization;

namespace TP2_serveur.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual Album Album { get; set; } = null!;
    }
}
