using GS.Application.Wrappers;
using MediatR;
using System;

namespace GS.Application.Features.Admin.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
