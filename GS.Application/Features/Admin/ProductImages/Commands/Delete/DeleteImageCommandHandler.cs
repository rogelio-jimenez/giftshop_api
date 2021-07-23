using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;

namespace GS.Application.Features.Admin.ProductImages.Commands.Delete
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteImageCommand, Response<Guid>>
    {
        private readonly IReadOnlyRepository _readOnlyRepo;
        private readonly IRepository _repository;

        public DeleteProductImageCommandHandler(IReadOnlyRepository readOnlyRepo, IRepository repository)
        {
            _readOnlyRepo = readOnlyRepo;
            _repository = repository;
        }

        public async Task<Response<Guid>> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyRepo.FirstAsync<Image>(i => i.Id.Equals(request.Id) && i.Status.Equals(EnabledStatus.Enabled));

            if (entity == null)
            {
                throw new ApiException("Image not found");
            }

            try
            {
                var fileFullPath = Path.Combine(entity.Url, entity.ProductId.ToString());
                var fileFullName = Path.Combine(fileFullPath, entity.Name);
                if (File.Exists(fileFullName))
                {
                    File.Delete(fileFullName);
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }

            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
            return new Response<Guid>(entity.Id);
        }
    }
}