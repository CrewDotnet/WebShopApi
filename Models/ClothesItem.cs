using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class ClothesItem
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public string? Name {get; set;}
        public decimal Price {get; set;}
        public Guid ClothesTypeId {get; set;} = Guid.Empty;
        public ClothesType ClothesType {get; set;} = null!;
        public List<JoiningOrderClothesItem> OrderClothesItems {get; set;} = new List<JoiningOrderClothesItem>();
    }
}