using System;
using GS.Application.Wrappers;
using MediatR;

namespace GS.Application.Features.Admin.ProductImages.Commands.DeleteAllByProduct
{
    public class DeleteAllByProductCommand : IRequest<Response<bool>>
    {
        public Guid productId { get; set; }
        public string FullNameFolder { get; set; }

        public DeleteAllByProductCommand(Guid productId, string fullNameFolder)
        {
            this.productId = productId;
            FullNameFolder = fullNameFolder;
        }
    }
}