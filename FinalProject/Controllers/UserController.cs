using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers {
    public class UserController : Controller {
        [HttpPost]
        [Consumes("application/json")]
        public JsonResult Login([FromBody] User user) {
            return Json(new { responseText = $"Username: {user.Username}\nPassword: {user.Password}" });
        }
    }
}
