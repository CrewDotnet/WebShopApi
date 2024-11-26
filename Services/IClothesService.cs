using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;

namespace WebShopApi.Services
{
    public interface IClothesService
    {
        Task<IEnumerable<ClothesItem>> GetAllAsync();
        Task<ClothesItem?> GetByIdAsync(Guid id);
        Task AddAsync(ClothesItem item);
        Task<bool> UpdateAsync(Guid id, ClothesItem item);
        Task<bool> DeleteAsync(Guid id);
    }
}