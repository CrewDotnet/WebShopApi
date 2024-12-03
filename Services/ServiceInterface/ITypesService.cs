using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;
using WebShopApi.Models.RequestModels;

namespace WebShopApi.Services
{
    public interface ITypesService
    {
        Task<IEnumerable<ClothesTypesResponse>> GetAllAsync();
        Task<ClothesTypesResponse?> GetByIdAsync(Guid id);
        Task<ClothesType> AddAsync(ClothesTypeRequest typeRequest);
        Task<bool> UpdateAsync(Guid id, ClothesTypeRequest typeRequest);
        Task<bool> DeleteAsync(Guid id);
    }
}