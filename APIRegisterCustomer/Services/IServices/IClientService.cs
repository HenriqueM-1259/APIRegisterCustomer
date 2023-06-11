using APIRegisterCustomer.Models;

namespace APIRegisterCustomer.Services.IServices
{
    public interface IClientService
    {
        List<Client> GetAll(int idUsers);
        Client GetById(int id);
        List<Client> GetByName(string name);
        Client GetByEmail(int idUsers, string EmailClient);
        string Create(Client client);
        string Update(Client client);
        string DesativaUsuario(int id);
    }
}
