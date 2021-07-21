using GS.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Products.Commands.Update
{
    public class UpdateProductCommand: IRequest<Response<Guid>>
    {
        public Guid Id { get; }
        public UpdateProductModel Product { get; set; }

        public UpdateProductCommand(Guid id, UpdateProductModel model)
        {
            Id = id;
            Product = model;
        }
    }
}
