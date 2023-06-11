using APIRegisterCustomer.Models;
using APIRegisterCustomer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIRegisterCustomer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly ClientService service;
       
        public ClientController(ClientService service)
        {
            this.service = service;
           
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            string jwtToken = Request.Headers["Authorization"];
            int idUser = TokenService.ObterUsuarioIdDoToken(jwtToken);
            var clientes = service.GetAll(idUser);

            return Ok(clientes);

        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Client client)
        {
            string jwtToken = Request.Headers["Authorization"];
            int idUser = TokenService.ObterUsuarioIdDoToken(jwtToken);
            client.UserId = idUser;
            string retornoCliente = service.Create(client);

            return Ok(retornoCliente);

        }
    }
}
