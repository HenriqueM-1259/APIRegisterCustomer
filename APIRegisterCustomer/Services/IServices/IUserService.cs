using APIRegisterCustomer.Models;

namespace APIRegisterCustomer.Services.IServices
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        List<User> GetByName(string name);
        User GetByEmail(string Email);
        User GetByEmailAndPassword(string Email,string Password);
        string Create(User user);
        string Update(User user);
        string DesativaUsuario(int id);

    }
}
