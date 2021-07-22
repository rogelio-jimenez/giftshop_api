using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;

namespace GS.Application.Features.Admin.ProductImages.Commands.Add
{
    public class AddImagesCommandHandler : IRequestHandler<AddImagesCommand, Response<bool>>
    {
        private readonly IReadOnlyRepository _readOnlyRepo;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddImagesCommandHandler(IRepository repository, IMapper mapper, IReadOnlyRepository readOnlyRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _readOnlyRepo = readOnlyRepo;
        }

        public async Task<Response<bool>> Handle(AddImagesCommand request, CancellationToken cancellationToken)
        {
            if (request.Images != null)
            {
                var productImagesFolder = Path.Combine(request.ImageAssetsFolderPath, request.ProductId.ToString());
                try
                {
                    if (!Directory.Exists(productImagesFolder))
                    {
                        Directory.CreateDirectory(productImagesFolder);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApiException(ex.Message);
                }

                foreach (var img in request.Images)
                {
                    var image = new AddImagesModel
                    {
                        Name = img.FileName,
                        LabelName = img.Name,
                        ByteSize = img.Length,
                        UserId = request.UserId,
                        ProductId = request.ProductId,
                        Url = request.ImageAssetsFolderPath
                    };

                    using (var fStream = new FileStream(Path.Combine(productImagesFolder, image.Name), FileMode.Create))
                    {
                        await img.CopyToAsync(fStream);
                    }

                    var newImg = _mapper.Map<Image>(image);
                    _repository.Add(newImg);
                }
                await _repository.SaveChangesAsync(cancellationToken);
            }
            return new Response<bool>(true);
        }
    }
}