using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Products.Commands
{
    public class AddProductModelValidator : AbstractValidator<AddProductModel>
    {
        public AddProductModelValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(64)
                .WithMessage("{PropertyName} exceeded max length of {MaxLength} characters.");
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(200)
                .WithMessage("{PropertyName} exceeded max length of {MaxLength} characters.");
            RuleFor(p => p.Price)
                .NotNull()
                .WithMessage("{PropertyName} must have a value.")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater tan 0.")
                .ScalePrecision(2, 10, ignoreTrailingZeros: true);
            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
