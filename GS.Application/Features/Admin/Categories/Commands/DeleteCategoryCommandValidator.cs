using FluentValidation;
using GS.Application.Features.Admin.Categories.Commands.Delete;
using System;

namespace GS.Application.Features.Admin.Categories.Commands
{
    public class DeleteCategoryCommandValidator: AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEqual(Guid.Empty);
        }
    }
}
