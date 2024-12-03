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
            // Mapping from Request models to Domain models
            CreateMap<ClothesItemRequest, ClothesItem>();
            CreateMap<ClothesTypeRequest, ClothesType>();
            CreateMap<CustomerRequest, Customer>();
            CreateMap<OrderRequest, Order>();

            // Mapping from Domain models to Response models
            CreateMap<ClothesItem, ClothesItemsResponse>();
            CreateMap<ClothesType, ClothesTypesResponse>();
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Order, OrderResponse>();
        }
    }
}