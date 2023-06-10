using APIRegisterCustomer.Models;
using APIRegisterCustomer.Services;
using APIRegisterCustomer.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public List<User> Get()
        {
             return service.GetAll(); 
        }
        [HttpGet("GetById")]
        public User GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpGet("GetByName")]
        public List<User> GetByName(string name)
        {
            return service.GetByName(name);
        }

        [HttpPost]
        public string Create([FromBody] User user)
        {
            try
            {
                return service.Create(user);
            }
            catch (Exception error)
            {

                return error.Message;
            }
            
        }

        [HttpPut]
        public string Update([FromBody] User user)
        {
            try
            {
                
                return service.Update(user); 
            }
            catch (Exception error)
            {

                return error.Message;
            }
           
        }

        
    }
}