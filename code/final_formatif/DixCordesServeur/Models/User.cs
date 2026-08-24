using Microsoft.AspNetCore.Identity;

namespace DixCordesServeur.Models
{
    public class User : IdentityUser
    {
        public virtual List<Message> Messages { get; set; } = new List<Message>();
        public virtual List<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
