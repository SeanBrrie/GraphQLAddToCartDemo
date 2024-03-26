using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.API.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        public Cart Cart { get; set; } = new Cart();


    }
}
