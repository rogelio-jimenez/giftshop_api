using FluentValidation;
using GS.Application.Features.Admin.Categories.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands
{
    public sealed class AddCategoryModelValidator: AbstractValidator<AddCategoryModel>
    {
        public AddCategoryModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotNull()
                .MaximumLength(32).WithMessage("{PropertyName} length {MaxLength} exceeded.");
            RuleFor(c => c.Description)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(64).WithMessage("{PropertyName} length {MaxLength} exceeded.");
            RuleFor(c => c.UserId)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .NotEqual(Guid.Empty);
        }
    }
}
