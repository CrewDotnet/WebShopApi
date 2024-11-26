using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShopApi.Data;
using WebShopApi.Models;

namespace WebShopApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _context.Orders
                .Include(o => o.OrderClothesItems)
                .ThenInclude(oi => oi.ClothesItem)
                .ToListAsync();

        public async Task<Order?> GetByIdAsync(Guid id) =>
            await _context.Orders
                .Include(o => o.OrderClothesItems)
                .ThenInclude(oi => oi.ClothesItem)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}