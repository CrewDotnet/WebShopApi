using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApi.Models;
using WebShopApi.Repositories;

namespace WebShopApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService (ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _repository.AddAsync(customer);
        }

        public async Task<bool> UpdateAsync(Guid id, Customer customer)
        {
            customer.Id = id;
            return await _repository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}