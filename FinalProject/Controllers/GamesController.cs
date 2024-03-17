using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;
using FinalProject.Models;
using System.Linq;

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

        public IActionResult GameLibrary()
        {
            var games = _context.Games.ToList();
            return View("_GameLibrary", games);
        }

        public IActionResult AddGame()
        {
            return View();
        }

        public UserDBContext Get_context() => _context;

        [HttpPost]
        [Consumes("application/json")]
        
        public JsonResult AddGame([FromBody] Game games)
        {
            if (ModelState.IsValid)
            {
                // Check if the game title already exists
                var gameExists = _context.Games.Any(g => g.Title == games.Title);
                if (gameExists)
                {
                    // If the game exists, do not add to the database and return an appropriate message
                    return Json(new { success = false, responseText = "This title already exists." });
                }
                // Since the tile does not exist, add the new game to the database
                _context.Games.Add(games);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    responseText = "Game resgistered!",
                    redirectToUrl = Url.Action("AddGame", "Games")
                });
            }
            else
            {
                // Model state is not valid, return an error message
                return Json(new { success = false, responseText = "Registration data is not valid." });
            }
        }
    }
}
