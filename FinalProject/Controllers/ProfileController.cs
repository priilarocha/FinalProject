using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
