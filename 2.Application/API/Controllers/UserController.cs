using Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <param name="user">Email e Senha do usuário</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
          if (user != null && user.Email == "admin" && user.Password == "admin")
              return Ok(new { response = "OK" });
          else
              return Unauthorized(new { response = "Failed" });
        }
    }
}
