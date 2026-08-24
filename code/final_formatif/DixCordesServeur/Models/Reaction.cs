using System.Text.Json.Serialization;

namespace DixCordesServeur.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public string MimeType { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public virtual Message Message { get; set; } = null!;
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
