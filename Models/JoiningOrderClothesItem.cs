using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class JoiningOrderClothesItem
    {
        public Guid OrderId {get; set;}
        public Order Order {get; set;} = null!;
        public Guid ClothesItemId {get; set;}
        public ClothesItem ClothesItem {get; set;} = null!;
    }
}