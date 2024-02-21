namespace FinalProject.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? Genre { get; set; }
        public List<Platform>? Platforms { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public List<Achievement> Achievements { get; set; }

    }

    public class Achievement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime? UnlockDate { get; set; }
        public int? Points { get; set; }
    }

    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
