using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class GamesController : Controller
    {
        private readonly UserDBContext _context;

        public GamesController(UserDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Helps prevent CSRF attacks
        public IActionResult AddGame(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction("GameLibrary"); // Redirect to the game library page
            }
            return View(game); // Return the view with validation errors
        }

        public IActionResult GameLibrary()
        {
            var games = _context.Games.ToList(); // Fetch games from the database
            return View("_GameLibrary", games); // Pass the games collection to the view
        }
        public IActionResult Edit(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(int id, Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction(nameof(GameLibrary));
            }
            return View(game);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(GameLibrary));
        }
    }
}
