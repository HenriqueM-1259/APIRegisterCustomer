﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRegisterCustomer.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }     
        public string Email { get; set; }

        public int? AddressId { get; set; }
        public Address? Address { get; set; }


        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

      
    }
}
