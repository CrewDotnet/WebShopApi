using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class ClothesItemsResponse
    {
        //public List<ClothesItem> ClothesItems {get; set;} = new List<ClothesItem>();
        public Guid Id {get; set;} = Guid.NewGuid();
        public string? Name {get; set;}
        public decimal Price {get; set;}
        public Guid ClothesTypeId {get; set;}
    }
            
}