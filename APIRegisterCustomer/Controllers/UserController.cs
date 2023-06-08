using APIRegisterCustomer.Models;
using APIRegisterCustomer.Services;
using APIRegisterCustomer.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIRegisterCustomer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }
        [HttpGet]
        public List<User> Get()
        {
            
             return service.GetAll(); 
        }
           
    
    }
}