using System.ComponentModel.DataAnnotations;

namespace APIRegisterCustomer.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string CityName { get; set; }
        public int ZipCode { get; set; }

    }
}
