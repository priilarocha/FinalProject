using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
