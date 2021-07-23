using System;
using GS.Application.Wrappers;
using MediatR;

namespace GS.Application.Features.Admin.ProductImages.Commands.Delete
{
    public class DeleteImageCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteImageCommand(Guid id)
        {
            Id = id;
        }
    }
}