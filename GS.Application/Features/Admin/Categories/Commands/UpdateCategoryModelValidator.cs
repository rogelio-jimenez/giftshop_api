using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands
{
    public class UpdateCategoryModelValidator: AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryModelValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotEqual(Guid.Empty);

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull()
                .MaximumLength(32).WithMessage("{PropertyName} length {MaxLength} exceeded.");

            RuleFor(c => c.Description)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(64).WithMessage("{PropertyName} length {MaxLength} exceeded.");

            RuleFor(c => c.UpdatedById)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotEqual(Guid.Empty);
        }
    }
}
