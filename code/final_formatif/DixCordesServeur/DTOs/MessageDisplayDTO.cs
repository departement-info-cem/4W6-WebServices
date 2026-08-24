using DixCordesServeur.Models;

namespace DixCordesServeur.DTOs
{
    public class MessageDisplayDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; }
        public List<ReactionDisplayDTO> Reactions { get; set; }
        public string Username { get; set; }

        public MessageDisplayDTO(Message message, User? user)
        {
            Id = message.Id;
            Text = message.Text;
            SentAt = message.SentAt;
            Reactions = message.Reactions.Select(r => new ReactionDisplayDTO(r, user)).ToList();
            Username = message.User.UserName!;
        }
    }
}
