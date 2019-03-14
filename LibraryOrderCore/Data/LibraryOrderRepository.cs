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
        public async Task<Order[]> GetAllOrdersAsync(bool includeItems = false)
        {
            IQueryable<Order> query = _context.Orders
                                        .Include(c => c.Customer);

            if (includeItems)
            {
                query = query
                            .Include(o => o.OrderItems)
                            .ThenInclude(i => i.Book);
            }
                                        
   
            // Order It
            query = query.OrderByDescending(o => o.OrderId);

            return await query.ToArrayAsync();

        }


        //Get Order
        public async Task<Order> GetOrderAsync(string orderNumber, bool includeItems = false)
        {
            IQueryable<Order> query = _context.Orders
                                                .Include(o => o.Customer);
                                                
            if (includeItems)
            {
                query = query
                    .Include(o => o.OrderItems)
                    .ThenInclude(o => o.Book);
            }

            // Query it
            query = query.Where(o => o.OrderNumber == orderNumber);

            return await query.FirstOrDefaultAsync();
        }






        // Get OrderItems by ID
        public async Task<OrderItem[]> GetOrderItemsByOrderNumberAsync(string orderNumber, bool includeItems = false)
        {
            IQueryable<OrderItem> query = _context.Items;

            if (includeItems)
            {
                query = query
                            .Include(i => i.Book);
            }


            // Add condition query
            query = query
                        .Where(i => i.Order.OrderNumber == orderNumber)
                        .OrderByDescending(i => i.OrderItemId);

            return await query.ToArrayAsync();
        }

        // Get OrderItem by ID
        public async Task<OrderItem> GetOrderItemByOrderNumberAsync(string orderNumber, int orderItemId, bool includeItems = false)
        {
            IQueryable<OrderItem> query = _context.Items;

            if(includeItems)
            {
                query = query
                            .Include(i => i.Book);
            }


            // Add condition query
            query = query
                        .Where(i => i.OrderItemId == orderItemId && i.Order.OrderNumber == orderNumber);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<Book[]> GetBooksByOrderNumberAsync(string orderNumber)
        {

            IQueryable<Book> query = _context.Items
              .Where(i => i.Order.OrderNumber == orderNumber)
              .Select(i => i.Book)
              .Where(b => b != null)
              .OrderBy(b => b.Title)
              .Distinct();

            return await query.ToArrayAsync();
        }


        public async Task<Book[]> GetAllBooksAsync()
        {
            var query = _context.Books
              .OrderBy(i => i.Title);

            return await query.ToArrayAsync();
        }

        public async Task<Book> GetBookAsync(int bookId)
        {

            var query = _context.Books
              .Where(b => b.BookId == bookId);

            return await query.FirstOrDefaultAsync();
        }





    }
}
