using DixCordesServeur.Models;

namespace DixCordesServeur.DTOs
{
    public class ReactionDisplayDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsToggled { get; set; }

        public ReactionDisplayDTO(Reaction reaction, User? user)
        {
            Id = reaction.Id;
            Quantity = reaction.Users.Count;
            IsToggled = user != null && reaction.Users.Contains(user);
        }
    }
}
