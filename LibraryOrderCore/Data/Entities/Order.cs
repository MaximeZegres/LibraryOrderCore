using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data.Entities
{
    public class Order
    {
        /// <summary>
        /// Id of the order
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// SKU/Reference of the order
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Date of validation of the order
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// True/False field to confirm the contact of the customer by the organization
        /// </summary>
        public bool IsContacted { get; set; }

        /// <summary>
        /// Collection of orderItems (books) ordered for the customer
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Reference of the customer who passed this order
        /// </summary>
        public Customer Customer { get; set; }
    }
}
