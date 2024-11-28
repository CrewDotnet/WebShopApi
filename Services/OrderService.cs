using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebShopApi.Models;
using WebShopApi.Models.RequestModels;
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

        public async Task<IEnumerable<OrderResponse>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderResponse>>(items);
        }

        public async Task<OrderResponse?> GetByIdAsync(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrderResponse?>(item);
        }

        public async Task<Order> AddAsync(OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.Id = Guid.NewGuid(); // Automatically generate ID
            await _repository.AddAsync(order);
            return order;
        }

        public async Task<bool> UpdateAsync(Guid id, OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.Id = id; // Assign the existing ID for update
            return await _repository.UpdateAsync(order);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}