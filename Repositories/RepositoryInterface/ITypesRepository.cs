using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;

namespace WebShopApi.Repositories
{
    public interface ITypesRepository
    {
        Task<IEnumerable<ClothesType>> GetAllAsync();
        Task<ClothesType?> GetByIdAsync(Guid id);
        Task AddAsync(ClothesType type);
        Task<bool> UpdateAsync(ClothesType type);
        Task<bool> DeleteAsync(Guid id);
    }
}