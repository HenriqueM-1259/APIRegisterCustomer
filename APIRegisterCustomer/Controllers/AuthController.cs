using APIRegisterCustomer.Models;
using APIRegisterCustomer.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIRegisterCustomer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:Controller
    {
        private readonly UserService service;

        public AuthController(UserService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult Auth(string Email, string Password)
        {
            if(string.IsNullOrEmpty(Email))
            {
                return BadRequest("Email Invalid");
            }

            if (string.IsNullOrEmpty(Password))
            {
                return BadRequest("Password Invalid");
            }

            User userBd = service.GetByEmailAndPassword(Email, Password);
            if (userBd == null)
            {

                return BadRequest("Usuario invalido");

            }
            var token = TokenService.GerarToken(userBd);
            return Ok(token);

        }
    }
}
