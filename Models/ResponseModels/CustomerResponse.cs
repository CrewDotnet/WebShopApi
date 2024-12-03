using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class CustomerResponse
    {
        //public List<Customer> Customers {get; set;} = new List<Customer>();
        public Guid Id {get; set;} = Guid.NewGuid();
        public string? Name {get; set;}
        public decimal TotalSpent {get; set;} = 0;
    }
}