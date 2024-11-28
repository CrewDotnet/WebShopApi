using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebShopApi.Models;
using WebShopApi.Repositories;

namespace WebShopApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _repository.AddAsync(order);
        }

        public async Task<bool> UpdateAsync(Guid id, Order order)
        {
            order.Id = id;
            return await _repository.UpdateAsync(order);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}