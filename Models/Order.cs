using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class Order
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public DateTime OrderDate {get; set;} = DateTime.Today;
        public decimal TotalPrice {get; set;}
        public Guid CustomerId {get;set;} //strani kljuc
        public Customer? Customer {get;set;} // avigation property - direktan pristup objektu Customer iz Ordera.
    }
}