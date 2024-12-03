using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class ClothesType
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public string? Type {get; set;}
        public List<ClothesItem> ClothesItems {get; set;} = new List<ClothesItem>(); // navigation property - pristup artiklima preko tipa
    }
}