using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public Book Book { get; set; }
        public bool IsOrdered { get; set; }
    }
}
