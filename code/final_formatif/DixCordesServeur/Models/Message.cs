using System.Text.Json.Serialization;

namespace DixCordesServeur.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public DateTime SentAt { get; set; }
        public virtual Channel Channel { get; set; } = null!;
        public virtual List<Reaction> Reactions { get; set; } = new List<Reaction>();
        public virtual User User { get; set; } = null!;
    }
}
