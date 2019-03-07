using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsContacted { get; set; }
        public ICollection<OrderItemModel> Items { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
