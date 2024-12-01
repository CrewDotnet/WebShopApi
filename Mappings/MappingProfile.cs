using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebShopApi.Models;
using WebShopApi.Models.RequestModels;

namespace WebShopApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for ClothesItem
            CreateMap<ClothesItemRequest, ClothesItem>();

            // Mapping for ClothesType
            CreateMap<ClothesTypeRequest, ClothesType>();

            // Mapping for Customer
            CreateMap<CustomerRequest, Customer>();

            // Mapping for Order
            CreateMap<OrderRequest, Order>();
        }
    }
}