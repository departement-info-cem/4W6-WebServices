using System.Text.Json.Serialization;

namespace Vincible.Models
{
    public class Superpower
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [JsonIgnore]
        public virtual List<Character> Characters { get; set; } = new List<Character>();
    }
}
