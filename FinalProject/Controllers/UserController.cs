using System.Linq;
using System;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class UserController : Controller
    {

        private readonly UserDBContext _context;

        public UserController(UserDBContext context)
        {
            _context = context;
        }

    
        
        [HttpPost]
        [Consumes("application/json")]
        public JsonResult Login([FromBody] UserLogin user)
        {
            // Retrieve the user from the database based on the provided username
            var dbUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);


            if (dbUser == null) // User not found in the database
            {
                return Json(new { success = false, responseText = "Invalid username." });
            }

            // Incorrect password
            if (dbUser.Password != user.Password)
            {

                return Json(new { success = false, responseText = "Incorrect password." });
            }

            // Authentication successful
            return Json(new { success = true, responseText = "Login successful.", redirectToUrl = Url.Action("Index", "Home") });
            
        }


        public UserDBContext Get_context() => _context;

        [HttpPost]
        [Consumes("application/json")]
        public JsonResult Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                // Check if the username/email already exists
                var userExists = _context.Users.Any(u => u.Username == user.Username || u.Email == user.Email);
                if (userExists)
                {
                    // If the user exists, do not add to the database and return an appropriate message
                    return Json(new { success = false, responseText = "Username or email already exists." });
                }

                // Since the user does not exist, add the new user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                // Respond with success and message
                return Json(new
                {
                    success = true, responseText = "Registration successful. Redirecting to login...", redirectToUrl = Url.Action("Index", "Home") });
            }
            else
            {
                // Model state is not valid, return an error message
                return Json(new { success = false, responseText = "Registration data is not valid." });
            }
        }

    }
}
