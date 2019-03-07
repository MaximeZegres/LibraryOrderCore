using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Models
{
    public class OrderItemModel
    {
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
        public OrderModel Order { get; set; }
        public bool IsOrdered { get; set; }
    }
}
