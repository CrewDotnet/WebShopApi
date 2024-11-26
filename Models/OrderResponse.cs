using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApi.Models
{
    public class OrderResponse
    {
        public List<Order> Orders {get; set;} = new List<Order>();
    }
}