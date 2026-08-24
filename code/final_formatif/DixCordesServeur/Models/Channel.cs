using System.Text.Json.Serialization;

namespace DixCordesServeur.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual List<Message> Messages { get; set; } = new List<Message>();
    }
}
