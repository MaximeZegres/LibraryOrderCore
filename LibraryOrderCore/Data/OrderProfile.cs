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
            this.CreateMap<Order, OrderModel>()
                .ForMember(o => o.CustomerFirstName, o => o.MapFrom(m => m.Customer.FirstName))
                .ReverseMap();

            this.CreateMap<OrderItem, OrderItemModel>()
                .ReverseMap()
                .ForMember(o => o.Order, opt => opt.Ignore())
                .ForMember(o => o.Book, opt => opt.Ignore());

            this.CreateMap<Book, BookModel>()
                .ReverseMap();
        }
    }
}
