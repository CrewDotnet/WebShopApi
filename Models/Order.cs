using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class Order
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public decimal TotalPrice {get; set;}
        public Guid CustomerId {get;set;} //strani kljuc
        public Customer? Customer {get;set;} // navigation property - direktan pristup objektu Customer iz Ordera.
        public List<ClothesItem> ClothesItems { get; set; } = new List<ClothesItem>(); // Navigation property for the many-to-many relationship
    }
}