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

        public string Create(User user)
        {
            User userConfirm = this.GetByEmail(user.EmailConfirm);
            if (userConfirm != null)
            {
                return "Email: " + userConfirm.EmailConfirm + "Ja existe";
            }
             _Context.Users.Add(user);
             _Context.SaveChanges();

            return "Usuario Registrado Com sucesso";
        }

        public string DesativaUsuario(int id)
        {
            User userReturn = this.GetById(id);
            if (userReturn != null)
            {
                userReturn.UsuarioActive = false;
                _Context.SaveChanges();
                return "Usuario desativado";
            }

            return "Usuario nao Encontrado";
        }

        public List<User> GetAll()
        {
            return _Context.Users.Where(Users => Users.UsuarioActive == true).ToList();
        }

        public User GetById(int id)
        {
            return _Context.Users.Where(Users => Users.Id == id && Users.UsuarioActive == true).FirstOrDefault();
        }

        public List<User> GetByName(string name)
        {
            return _Context.Users.Where(Users => Users.Name == name && Users.UsuarioActive == true).ToList();
        }
        public User GetByEmail(string Email)
        {
            return _Context.Users.Where(Users => Users.EmailConfirm == Email).FirstOrDefault();
        }

        public string Update(User user)
        {
            User userReturn = _Context.Users.Find(user);
            if (userReturn != null)
            {
                _Context.Users.Update(userReturn);
                return "User Alterado";
            }
            return "User nao existe";
        }
    }
}
