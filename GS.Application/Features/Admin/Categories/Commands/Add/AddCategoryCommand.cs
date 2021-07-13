using GS.Application.Wrappers;
using MediatR;
using System;

namespace GS.Application.Features.Admin.Categories.Commands.Add
{
    public class AddCategoryCommand: IRequest<Response<Guid>>
    {
        public AddCategoryModel Category { get; set; }
        public AddCategoryCommand(AddCategoryModel category)
        {
            Category = category;
        }
    }
}
