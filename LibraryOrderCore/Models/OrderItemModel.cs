using LibraryOrderCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Models
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
        public bool IsOrdered { get; set; }
        
    }
}
