using System;
using System.Web;
using FinalProject.Data;
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
        public JsonResult Login([FromBody] User user) {
            return Json(new { responseText = $"Username: {user.Username}\nPassword: {user.Password}" });
        }
    }
}
