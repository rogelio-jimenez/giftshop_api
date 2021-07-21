using AutoMapper;
using AutoMapper.QueryableExtensions;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Products.Queries.GetById
{
    public sealed class GetProductQueryHandler: IRequestHandler<GetProductQuery, Response<ProductModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepo;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IReadOnlyRepository readOnlyRepo, IMapper mapper)
        {
            _readOnlyRepo = readOnlyRepo;
            _mapper = mapper;
        }

        public async Task<Response<ProductModel>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepo.Query<Product>(p => p.Id.Equals(request.Id) && p.Status == EnabledStatus.Enabled)
                .ProjectTo<ProductModel>(_mapper.ConfigurationProvider);

            var result = await _readOnlyRepo.SingleAsync(query, cancellationToken);

            if (result == null)
            {
                //ToDo: create an appropiate exception for not found...
                throw new ApiException("Product not found");
            }

            return new Response<ProductModel>(result);
        }
    }
}
