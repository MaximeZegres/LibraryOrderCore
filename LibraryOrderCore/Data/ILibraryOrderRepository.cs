﻿using LibraryOrderCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data
{
    public interface ILibraryOrderRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Orders
        Task<Order[]> GetAllOrdersAsync(bool includeItems = false);
        Task<Order> GetOrderAsync(int id);
    }
}
