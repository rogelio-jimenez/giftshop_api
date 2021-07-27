using System.IO;
using AutoMapper;
using GS.Application.Features.Admin.ProductImages.Commands;
using GS.Application.Features.Admin.ProductImages.Queries.GetByProductId;
using GS.Domain.Entities;

namespace GS.Application.Features.Admin.ProductImages
{
    public class ImageModelMapping : Profile
    {
        public ImageModelMapping()
        {
            _ = CreateMap<AddImagesModel, Image>();
            _ = CreateMap<Image, ListItemImageModel>()
                .ForMember(im => im.RelativePath, i => i.Ignore());
        }
    }
}
