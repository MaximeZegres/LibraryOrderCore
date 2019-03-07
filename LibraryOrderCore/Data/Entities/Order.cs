using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsContacted { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public Customer Customer { get; set; }
    }
}
