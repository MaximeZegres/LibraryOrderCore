﻿using LibraryOrderCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrderCore.Data
{
    public class LibraryOrderRepository : ILibraryOrderRepository
    {
        private readonly LibraryOrderDbContext _context;

        public LibraryOrderRepository(LibraryOrderDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }


        // Get All Orders
        public async Task<Order[]> GetAllOrdersAsync(bool includeItems = false)
        {
            IQueryable<Order> query = _context.Orders
                                        .Include(c => c.Customer);

            if (includeItems)
            {
                query = query
                  .Include(o => o.OrderItems)
                   .ThenInclude(o => o.Book);
            }

            // Order It
            query = query.OrderByDescending(o => o.OrderDate);

            return await query.ToArrayAsync();

        }


        //Get Order
        public async Task<Order> GetOrderAsync(int id)
        {
            IQueryable<Order> query = _context.Orders
                                                .Include(o => o.Customer)
                                                .Include(o => o.OrderItems)
                                                .ThenInclude(o => o.Book);

            // Query it
            query = query.Where(o => o.Id == id);

            return await query.FirstOrDefaultAsync();
        }


        // Get OrderItems by ID
        public async Task<OrderItem[]> GetOrderItemsAsync(int id)
        {
            IQueryable<OrderItem> query = _context.Items
                                                    .Include(i => i.Book);


            // Add condition query
            query = query
                        .Where(i => i.Order.Id == id)
                        .OrderByDescending(i => i.OrderItemId);

            return await query.ToArrayAsync();
        }



    }
}
