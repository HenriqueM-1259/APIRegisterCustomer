using APIRegisterCustomer.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIRegisterCustomer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {



        public IEnumerable<User> Get()
        {
            List<User> user = new List<User>(){
                 new User
                {
                    AddressId = 1,
                    Email = "teste"
                }
                
            };
             return user;
        }
           
    
    }
}