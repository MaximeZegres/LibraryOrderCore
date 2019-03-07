using LibraryOrderCore.Data.Entities;
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
        public async Task<Order[]> GetAllCampsAsync(bool includeItems = false)
        {
            IQueryable<Order> query = _context.Orders
                                        .Include(o => o.Customer);

            if (includeItems)
            {
                query = query
                  .Include(o => o.Items)
                  .ThenInclude(i => i.Book);
            }

            // Order It
            query = query.OrderByDescending(o => o.Id);

            return await query.ToArrayAsync();
        }

    }
}
