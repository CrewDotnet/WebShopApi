using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;

namespace WebShopApi.Repositories
{
    public interface IClothesRepository
    {
        Task<IEnumerable<ClothesItem>> GetAllAsync();
        Task<ClothesItem?> GetByIdAsync(Guid id);
        Task AddAsync(ClothesItem item);
        Task<bool> UpdateAsync(ClothesItem item);
        Task<bool> DeleteAsync(Guid id);
    }
}