using System.Linq;
using System;
using System.Web;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers {
    public class UserController : Controller {

        private readonly UserDBContext _context;

        public UserController(UserDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Consumes("application/json")]
        public JsonResult Login([FromBody] User user)
        {
            // Retrieve the user from the database based on the provided username
            // var dbUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);

            /*if (dbUser == null)
            {
                // User not found in the database
                return Unauthorized(); // 401 Unauthorized status code
            }

            // Validate the password
            if (dbUser.Password != user.Password)
            {
                // Incorrect password
                return Unauthorized(); // 401 Unauthorized status code
            }*/

            // Authentication successful
            // You might generate and return a token here for subsequent authenticated requests
            // return Json(new { responseText = $"Username: {user.Username}. Password: {user.Password}." }); // 200 OK status code
            return Json(new { responseText = "Server RESPONSE" });
        }
    }
}
