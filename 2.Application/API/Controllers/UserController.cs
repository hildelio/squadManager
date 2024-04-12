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
        public IActionResult Login(UserLoginModel user)
        {
          if (user != null && user.Email == "admin" && user.Password == "admin")
              return Ok(new { response = "OK" });
          else
              return Unauthorized(new { response = "Failed" });
        }

        [HttpPost("create")]
        public IActionResult Create(UserModel user)
        {
          if (user != null)
                return Ok(new { response = "OK" });
            else
                return BadRequest(new { response = "Failed"});
        }
    }
}
