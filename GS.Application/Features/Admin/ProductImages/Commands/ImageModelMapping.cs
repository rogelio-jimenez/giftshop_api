using AutoMapper;
using GS.Domain.Entities;

namespace GS.Application.Features.Admin.ProductImages.Commands
{
    public class ImageModelMapping: Profile
    {
        public ImageModelMapping()
        {
            _ = CreateMap<AddImagesModel, Image>();

        }
    }
}
