using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;
using WebShopApi.Repositories;

namespace WebShopApi.Services
{
    public class TypesService : ITypesService
    {
        private readonly ITypesRepository _repository;

        public TypesService (ITypesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClothesType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ClothesType?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ClothesType type)
        {
            await _repository.AddAsync(type);
        }

        public async Task<bool> UpdateAsync(Guid id, ClothesType type)
        {
            type.Id = id;
            return await _repository.UpdateAsync(type);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}