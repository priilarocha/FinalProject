using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
