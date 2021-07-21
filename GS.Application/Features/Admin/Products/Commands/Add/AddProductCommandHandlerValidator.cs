using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Products.Commands.Add
{
    public sealed class AddProductCommandHandlerValidator: AbstractValidator<AddProductCommand>
    {
        public AddProductCommandHandlerValidator()
        {
            RuleFor(p => p.Product)
                .NotNull();

            var innerValidator = new AddProductModelValidator();
            RuleFor(p => p.Product)
                .SetValidator(innerValidator);
        }
    }
}
