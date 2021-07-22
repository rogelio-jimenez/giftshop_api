using AutoMapper;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Products.Commands.Add
{
    public sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, Response<Guid>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IReadOnlyRepository readOnlyRepository, IRepository repository, IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _readOnlyRepository.FirstAsync<Category>(c =>
                c.Id.Equals(request.Product.CategoryId) && c.Status.Equals(EnabledStatus.Enabled));

            if (category == null)
            {
                throw new ApiException("The Category for this product is not valid.");
            }

            var entity = await _readOnlyRepository.FirstAsync<Product>(
                    p => p.Name.ToLower().Trim().Equals(request.Product.Name.ToLower().Trim())
                    && p.Description.ToLower().Trim().Equals(request.Product.Description.ToLower().Trim())
                    //&& p.Price.Equals(request.Product.Price)
                    && p.CategoryId.ToString().ToLower().Equals(request.Product.CategoryId.ToString().ToLower())
                );

            if (entity != null)
            {
                throw new ApiException("There is a product with same values and category.");
            }

            var newProduct = _mapper.Map<Product>(request.Product);
            _repository.Add(newProduct);
            await _repository.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(newProduct.Id);
        }
    }
}
