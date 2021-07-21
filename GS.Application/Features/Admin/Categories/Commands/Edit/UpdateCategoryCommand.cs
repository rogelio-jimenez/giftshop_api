using GS.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands.Edit
{
    public class UpdateCategoryCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public UpdateCategoryModel Category { get; set; }
        public UpdateCategoryCommand(Guid id, UpdateCategoryModel model)
        {
            Id = id;
            Category = model;
        }
    }
}
