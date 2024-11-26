using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class Customer
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public string? Name {get; set;}
        public decimal TotalSpent {get; set;} = 0;
        public bool HasDiscount {get; set;} = false;
        public List<Order> Orders {get; set;} = new List<Order>();
    }
}