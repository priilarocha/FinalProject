namespace FinalProject.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public List<Game> FavoriteGames { get; set; }
        // Relationships
        public virtual ICollection<Game> Games { get; set; } // User's game library
        public virtual ICollection<Achievement> Achievements { get; set; } // User's achievements
        public virtual ICollection<UserProfile> Friends { get; set; } // User's friends

        // Constructor to initialize collections
        public UserProfile()
        {
            Games = new HashSet<Game>();
            Achievements = new HashSet<Achievement>();
            Friends = new HashSet<UserProfile>();
            FavoriteGames = new List<Game>(); // Initialize the list
        }
    }
}
