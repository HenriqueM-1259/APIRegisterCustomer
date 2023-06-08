using APIRegisterCustomer.Models;

namespace APIRegisterCustomer.Services.IServices
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        List<User> GetByName(string name);
        User Create(User user);
        User Update(User user);
        void Delete(int id);

    }
}
