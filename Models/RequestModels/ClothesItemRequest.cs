using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models.RequestModels
{
    public class ClothesItemRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ClothesTypeId { get; set; }
    }
}