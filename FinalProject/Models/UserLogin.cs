namespace FinalProject.Models
{
    public class UserLogin
    {
        // I don't need to have a primary key here, because I'm not going to store this in the database, it's just for the login form
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
