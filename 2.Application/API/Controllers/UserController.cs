using API.Validator; // Importa o namespace onde está definido UserValidator
using Microsoft.AspNetCore.Mvc;
using System;
using FluentValidation.Results;
using FluentValidation;
using Common; // Importa o namespace onde estão definidos UserLoginModel e UserModel

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
            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                return BadRequest(new { response = "Failed", errors = results.Errors });
            }
            
            if (user != null && user.Email == "admin" && user.Password == "admin")
                return Ok(new { response = "OK" });
            else
                return Unauthorized(new { response = "Failed" });
        }
        
        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="user">Nome, Email, Senha e  Confirmação de Senha do Usuário</param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(UserModel user)
        {
            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                return BadRequest(new { response = "Failed", errors = results.Errors });
            }

            if (user != null)
                return Ok(new { response = "OK" });
            else
                return BadRequest(new { response = "Failed" });
        }
    }
}
