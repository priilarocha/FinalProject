using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly Data.UserDBContext _context;

        public RegistrationController(Data.UserDBContext context)
        {
            _context = context;
        }



        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Add the user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                // Optionally, redirect to a success page or display a success message
                return RedirectToAction("Success");
            }

            // If the model state is not valid, return the registration page with errors
            return View();
        }


    }
}

