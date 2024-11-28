using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models.RequestModels
{
    public class OrderRequest
    {
        public decimal TotalPrice {get; set;}
        public Guid CustomerId {get;set;} //strani kljuc
        public List<Guid> ClothesItemsId { get; set; } = new List<Guid>();
    }
}