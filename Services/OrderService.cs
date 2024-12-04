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
        private readonly IOrderRepository _orderRepository;
        private readonly IClothesRepository _itemRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper, IClothesRepository itemRepository)
        {
            _orderRepository = repository;
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<OrderResponse>> GetAllAsync()
        {
            var items = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderResponse>>(items);
        }

        public async Task<OrderResponse?> GetByIdAsync(Guid id)
        {
            var item = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderResponse?>(item);
        }

        public async Task<Order> AddAsync(OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.Id = Guid.NewGuid(); // Automatically generate ID

            foreach (var clothesItemId in orderRequest.ClothesItemsId)
            {
                var clothesItem = await _itemRepository.GetByIdAsync(clothesItemId);
                order.ClothesItems.Add(clothesItem);
            }

            // Ručno izračunaj i postavi TotalPrice
            order.TotalPrice = order.ClothesItems.Sum(item => item.Price);

            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<bool> UpdateAsync(Guid id, OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.Id = id; // Assign the existing ID for update
            return await _orderRepository.UpdateAsync(order);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _orderRepository.DeleteAsync(id);
        }
    }
}