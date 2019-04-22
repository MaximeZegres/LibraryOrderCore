using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data.Entities
{
    public class OrderItem
    {
        /// <summary>
        /// Id of the orderItem
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// Reference to the Order the orderItems is linked to
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Quantity of orderItems ordered
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Reference to the specific item (book) ordered
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// True/False value to confirm that the books was ordered internally in the organization
        /// </summary>
        public bool IsOrdered { get; set; }
    }
}
