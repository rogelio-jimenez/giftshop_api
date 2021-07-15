using AutoMapper;
using GS.Application.Features.Admin.Categories.Commands;
using GS.Application.Models.Category;
using GS.Domain.Entities;

namespace GS.Application.Features.Admin.Categories
{
    public class CategoryMapping: Profile
    {
        public CategoryMapping()
        {
            _ = CreateMap<AddCategoryModel, Category>()
                .ForMember(cm => cm.Id, c => c.Ignore());

            _ = CreateMap<UpdateCategoryModel, Category>();

            _ = CreateMap<Category, AddCategoryModel>();

            _ = CreateMap<Category, CategoryModel>();

            _ = CreateMap<CategoryModel, Category>();
        }
    }
}
