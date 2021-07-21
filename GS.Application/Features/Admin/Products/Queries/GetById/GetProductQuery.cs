using GS.Application.Wrappers;
using MediatR;
using System;

namespace GS.Application.Features.Admin.Products.Queries.GetById
{
    public class GetProductQuery : IRequest<Response<ProductModel>>
    {
        public Guid Id { get; set; }

        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
