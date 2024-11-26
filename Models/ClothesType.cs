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
    }
}