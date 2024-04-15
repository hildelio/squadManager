using API.Validator;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Common;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly UserService _userService;

        public UserController(PersonService personService, UserService userService)
        {
            _personService = personService;
            _userService = userService;
        }

        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <param name="user">Email e Senha do Usuário</param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login(UserLoginModel user)
        {
            UserLoginValidator validator = new UserLoginValidator();
            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                return BadRequest(new { response = "Failed", errors = results.Errors });
            }

            if (user != null && user.Email == "admin" && user.Password == "admin")
            {
                return Ok(new { response = "OK" });
            }
            else
            {
                return Unauthorized(new { response = "Failed" });
            }                
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="user">Nome, Email, Senha e Confirmação de Senha do Usuário</param>
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

            var personId = _personService.AddPerson(new PersonModel()
            {
                Username = user.Person.Username,
                Email = user.Person.Email
            });

            _userService.AddUser(new UserModel()
            {
                PersonId = personId,
                Password = user.Password
            });   

            return Ok(new { response = "OK" });
        }
        
        /// <summary>
        /// Recupera a senha do usuário
        /// </summary>
        /// <param name="user">Email do Usuário</param>
        /// <returns></returns>
        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(UserForgotPasswordModel user)
        {
            UserForgotPasswordValidator validator = new UserForgotPasswordValidator();
            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                return BadRequest(new { response = "Failed", errors = results.Errors });
            }

            if (user != null)
            {
                return Ok(new { response = "OK" });
            }
            else
            {
                return BadRequest(new { response = "Failed" });
            }                
        }
        
        /// <summary>
        /// Reseta a senha do usuário
        /// </summary>
        /// <param name="user">Senha e Confirmação de Senha do Usuário</param>
        /// <returns></returns>
        [HttpPost("reset-password")]
        public IActionResult ResetPassword(UserResetPasswordModel user)
        {
            UserResetPasswordValidator validator = new UserResetPasswordValidator();
            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                return BadRequest(new { response = "Failed", errors = results.Errors });
            }

            if (user != null)
            {
                return Ok(new { response = "OK" });
            }
            else
            {
                return BadRequest(new { response = "Failed" });
            }                
        }
    }
}
