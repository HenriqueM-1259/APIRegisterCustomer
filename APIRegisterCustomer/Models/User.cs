using System.ComponentModel.DataAnnotations;

namespace APIRegisterCustomer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailConfirm { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool UsuarioActive { get; set; }
        public List<Client> Clients { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
