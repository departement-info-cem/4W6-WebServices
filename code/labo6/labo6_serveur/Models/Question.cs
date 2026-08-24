namespace labo6_serveur.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int Correct { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
    }
}
