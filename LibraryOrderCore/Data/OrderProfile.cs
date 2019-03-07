using AutoMapper;
using LibraryOrderCore.Data.Entities;
using LibraryOrderCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, OrderModel>();
        }
    }
}
