using LibraryOrderCore.Data.Entities;
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
        Task<Order> GetOrderAsync(string orderNumber, bool includeItems = false);

        // OrderItems
        Task<OrderItem[]> GetOrderItemsByOrderNumberAsync(string orderNumber, bool includeItems = false);
        Task<OrderItem> GetOrderItemByOrderNumberAsync(string orderNumber, int orderItemId, bool includeItems = false);

        // Books
        Task<Book[]> GetBooksByOrderNumberAsync(string orderNumber);
        Task<Book[]> GetAllBooksAsync();
        Task<Book> GetBookAsync(int bookId);
    }
}
