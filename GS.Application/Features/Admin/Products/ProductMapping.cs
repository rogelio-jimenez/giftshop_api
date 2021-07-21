﻿using AutoMapper;
using GS.Application.Features.Admin.Products.Commands;
using GS.Application.Features.Admin.Products.Queries;
using GS.Domain.Entities;

namespace GS.Application.Features.Admin.Products
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            _ = CreateMap<Product, AddProductModel>();

            _ = CreateMap<AddProductModel, Product>()
                .ForMember(p => p.Id, m => m.Ignore());

            _ = CreateMap<UpdateProductModel, Product>();

            _ = CreateMap<Product, ProductModel>();
        }
    }
}