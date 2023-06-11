using APIRegisterCustomer.Data;
using APIRegisterCustomer.Models;
using APIRegisterCustomer.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIRegisterCustomer.Services
{
    public class ClientService : IClientService
    {
        private readonly DataContext _Context;
        public ClientService(DataContext dataContext)
        {

            this._Context = dataContext;

        }
        public string Create(Client client)
        {
            _Context.Clients.Add(client);
            _Context.SaveChanges();
            return client.Name;
        }

        public string DesativaUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAll(int idUsers)
        {
            return _Context.Clients.Where(cliente => cliente.UserId == idUsers).ToList();
        }

        public Client GetByEmail(int idUsers, string EmailClient)
        {
            return _Context.Clients.Where(cliente => cliente.UserId == idUsers && cliente.Email == EmailClient).FirstOrDefault();
        }

        public Client GetById(int idUsers, int IdCliente)
        {
            return _Context.Clients.Where(cliente => cliente.UserId == idUsers && cliente.Id == IdCliente).FirstOrDefault();
        }

        public List<Client> GetByName(int IdUser,string NameCliente)
        {
            return _Context.Clients.Where(cliente => cliente.Name == NameCliente && cliente.UserId == IdUser).ToList();
        }

        public string Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
