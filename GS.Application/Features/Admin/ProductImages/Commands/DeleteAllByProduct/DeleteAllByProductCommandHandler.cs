using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;

namespace GS.Application.Features.Admin.ProductImages.Commands.DeleteAllByProduct
{
    public class DeleteAllByProductCommandHandler : IRequestHandler<DeleteAllByProductCommand, Response<bool>>
    {
        private readonly IReadOnlyRepository _readOnlyRepo;
        private readonly IRepository _repository;

        public DeleteAllByProductCommandHandler(IReadOnlyRepository readOnlyRepo, IRepository repository)
        {
            _readOnlyRepo = readOnlyRepo;
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(DeleteAllByProductCommand request, CancellationToken cancellationToken)
        {
            var entities = await _readOnlyRepo.ListAsync<Image>(i => i.ProductId.Equals(request.productId));

            if (entities == null)
            {
                throw new ApiException("There is no images found for the specified product.");
            }

            var fullFolderPath = Path.Combine(request.FullNameFolder, request.productId.ToString());
            Directory.Delete(fullFolderPath, true);

            _repository.RemoveAll(entities);
            await _repository.SaveChangesAsync();

            return new Response<bool>(true);
        }
    }
}