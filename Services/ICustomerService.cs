using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;

namespace WebShopApi.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(Guid id);
        Task AddAsync(Customer customer);
        Task<bool> UpdateAsync(Guid id, Customer customer);
        Task<bool> DeleteAsync(Guid id);
    }
}