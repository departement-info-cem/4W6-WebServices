using System.ComponentModel.DataAnnotations.Schema;

namespace serveur16.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public string Game { get; set; } = null!;
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; } = null!;

        [InverseProperty("Reviews")]
        public virtual User Author { get; set; } = null!;

        [InverseProperty("UpvotedReviews")]
        public virtual List<User> Upvoters { get; set; } = new List<User>();
    }
}
