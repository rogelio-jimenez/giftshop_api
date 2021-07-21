using GS.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Products.Commands.Add
{
    public class AddProductCommand: IRequest<Response<Guid>>
    {
        public AddProductModel Product { get; set; }

        public AddProductCommand(AddProductModel product)
        {
            Product = product;
        }
    }
}
