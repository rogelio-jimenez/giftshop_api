using System;
using System.ComponentModel.DataAnnotations;
using GS.Application.Queries;
using MediatR;

namespace GS.Application.Features.Admin.ProductImages.Queries.GetByProductId
{
    public class GetImagesPageQuery : PaginatedQueryRequest<ListItemImageModel>
    {
        [Required]
        public Guid ProductId { get; set; }
    }
}