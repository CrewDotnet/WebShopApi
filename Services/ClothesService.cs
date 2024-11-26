using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShopApi.Models;
using WebShopApi.Repositories;

namespace WebShopApi.Services
{
    public class ClothesService : IClothesService
    {
        private readonly IClothesRepository _repository;

        public ClothesService(IClothesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClothesItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ClothesItem?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ClothesItem item)
        {
            await _repository.AddAsync(item);
        }

        public async Task<bool> UpdateAsync(Guid id, ClothesItem item)
        {
            return await _repository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}