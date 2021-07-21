using GS.Application.Wrappers;
using MediatR;
using System;

namespace GS.Application.Features.Admin.Categories.Commands.Delete
{
    public class DeleteCategoryCommand: IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public Guid UpdatedById { get; set; }

        public DeleteCategoryCommand(Guid id, Guid updatedById)
        {
            Id = id;
            UpdatedById = updatedById;
        }
    }
}
