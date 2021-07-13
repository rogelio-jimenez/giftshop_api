using GS.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands.Edit
{
    public class UpdateCategoryCommand : IRequest<Response<Guid>>
    {
        public UpdateCategoryModel Category { get; set; }
        public UpdateCategoryCommand(UpdateCategoryModel model)
        {
            Category = model;
        }
    }
}
