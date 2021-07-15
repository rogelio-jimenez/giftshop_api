using GS.Application.Models.Category;
using GS.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<Response<CategoryModel>>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
