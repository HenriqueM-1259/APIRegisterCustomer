using APIRegisterCustomer.Data;
using APIRegisterCustomer.Models;
using APIRegisterCustomer.Services.IServices;
using System.Data;

namespace APIRegisterCustomer.Services
{
    public class UserService: IUserService
    {
        private readonly DataContext _Context;
        public UserService(DataContext dataContext)
        {

           this._Context = dataContext;

        }

        public User Create(User user)
        {
             _Context.Users.Add(user);
             _Context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
           _Context.Remove(id);
           _Context.SaveChanges();

        }

        public List<User> GetAll()
        {
            return _Context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _Context.Users.Where(Users => Users.Id == id).FirstOrDefault();
        }

        public List<User> GetByName(string name)
        {
            return _Context.Users.Where(Users => Users.Name == name).ToList();
        }

        public User Update(User user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,

            };
        }
    }
}
