using AutoMapper;
using AutoMapper.QueryableExtensions;
using GS.Application.Contracts.Persistence;
using GS.Application.Models.Category;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Queries.GetById
{
    public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryModel>>
    {
        //private readonly IRepositoryAsync<Category> _repository;
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IReadOnlyRepository repository, IMapper mapper)
        {
            _readOnlyRepository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CategoryModel>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            //var entity = await _readOnlyRepository.GetByIdAsync(request.Id);

            var query = _readOnlyRepository.Query<Category>(
                c => c.Id.Equals(request.Id) && c.Status == EnabledStatus.Enabled)
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider);

            var entity = await _readOnlyRepository.SingleAsync(query, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Category with id: {request.Id} not found");
            }

            return new Response<CategoryModel>(entity);
        }
    }
}
