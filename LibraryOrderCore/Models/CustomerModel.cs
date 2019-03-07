using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
