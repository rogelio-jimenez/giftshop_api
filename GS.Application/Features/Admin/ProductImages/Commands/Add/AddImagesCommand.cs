using System;
using System.Collections.Generic;
using GS.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GS.Application.Features.Admin.ProductImages.Commands.Add
{
    public class AddImagesCommand : IRequest<Response<bool>>
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        public string ImageAssetsFolderPath { get; set; }

        public AddImagesCommand(Guid productId, Guid userId, IEnumerable<IFormFile> models, string imageAssetsFolderPath)
        {
            ProductId = productId;
            UserId = userId;
            Images = models;
            ImageAssetsFolderPath = imageAssetsFolderPath;
        }
    }
}