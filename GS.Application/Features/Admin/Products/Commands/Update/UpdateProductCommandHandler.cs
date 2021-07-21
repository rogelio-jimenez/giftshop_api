using AutoMapper;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Products.Commands.Update
{
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<Guid>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IReadOnlyRepository readOnlyRepository, IRepository repository, IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyRepository.FirstAsync<Product>(
                p => p.Id.Equals(request.Id) && p.Status.Equals(EnabledStatus.Enabled));

            if (entity == null)
            {
                throw new ApiException("Product not found");
            }

            var productWithSameValues = await _readOnlyRepository.FirstAsync<Product>(
                p => !p.Id.ToString().ToLower().Equals(request.Id.ToString().ToLower())
                && (
                    p.Name.ToLower().Trim().Equals(request.Product.Name.ToLower().Trim())
                    && p.CategoryId.Equals(request.Product.CategoryId)
                    && p.Description.ToLower().Trim().Equals(request.Product.Description.ToLower().Trim())
                    && p.Price.Equals(request.Product.Price)
                )
            );

            if (productWithSameValues != null)
            {
                throw new ApiException($"Product with same values already exists Product id {productWithSameValues.Id}.");
            }

            request.Product.UserId = entity.UserId;
            
            _mapper.Map(request.Product, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(entity.Id);
        }
    }
}
