using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;
using WebShopApi.Models.RequestModels;

namespace WebShopApi.Services
{
    public interface IClothesService
    {
        Task<IEnumerable<ClothesItemsResponse>> GetAllAsync();
        Task<ClothesItemsResponse?> GetByIdAsync(Guid id);
        Task<ClothesItem> AddAsync(ClothesItemRequest request);
        Task<bool> UpdateAsync(Guid id, ClothesItemRequest item);
        Task<bool> DeleteAsync(Guid id);
    }
}