using AutoMapper;
using GS.Domain.Entities;
using GS.Domain.Models;

namespace GS.Application.Features.Admin.Products.Queries
{
    public class ProductListItemMapping : Profile
    {
        public ProductListItemMapping()
        {
            _ = CreateMap<Product, ProductListItemModel>()
                .ForMember(p =>
                    p.Category, m =>
                        m.MapFrom(pc =>
                            pc.Category != null && pc.Category.Status == EnabledStatus.Enabled ? pc.Category.Name : ""));
        }
    }
}
