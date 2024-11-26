using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;

namespace WebShopApi.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task<bool> UpdateAsync(Guid id, Order order);
        Task<bool> DeleteAsync(Guid id);
    }
}