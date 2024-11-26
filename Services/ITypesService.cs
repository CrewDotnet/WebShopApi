using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;

namespace WebShopApi.Services
{
    public interface ITypesService
    {
        Task<IEnumerable<ClothesType>> GetAllAsync();
        Task<ClothesType?> GetByIdAsync(Guid id);
        Task AddAsync(ClothesType type);
        Task<bool> UpdateAsync(Guid id, ClothesType type);
        Task<bool> DeleteAsync(Guid id);
    }
}