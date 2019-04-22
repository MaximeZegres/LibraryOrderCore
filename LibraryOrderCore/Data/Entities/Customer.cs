using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data.Entities
{
    public class Customer
    {
        /// <summary>
        /// Id of customer
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// FirstName of customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName of customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email of Customer
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// PhoneNumber of customer
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
