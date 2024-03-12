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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGame(Game model)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(model);
                _context.SaveChanges();
                return RedirectToAction("GameLibrary");
            }

            return View(model);
        }
    }
}
