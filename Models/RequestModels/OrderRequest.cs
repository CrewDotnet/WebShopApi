using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models.RequestModels
{
    public class OrderRequest
    {
        public Guid CustomerId {get;set;} //strani kljuc
        public List<Guid> ClothesItemsId { get; set; } = new List<Guid>();
    }
}