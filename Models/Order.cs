using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class Order
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public DateTime OrderDate {get; set;}
        public decimal TotalPrice {get; set;}
        public List<JoiningOrderClothesItem> OrderClothesItems {get; set;} = new List<JoiningOrderClothesItem>();
        public Guid CustomerId {get;set;}
        public Customer? Customer {get;set;}
    }
}