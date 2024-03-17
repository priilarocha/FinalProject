using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? Genre { get; set; }
        public List<Platform>? Platforms { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public List<Achievement>? Achievements { get; set; }

    }

    public class Achievement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } // Indicates if the user has completed this achievement
        public int GameId { get; set; } // Foreign key to associate achievement with a game
        public virtual Game? Game { get; set; } // Navigation property to the Game
        public DateTime? UnlockDate { get; set; }
        public int? Points { get; set; }

    }

    public class Platform
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
