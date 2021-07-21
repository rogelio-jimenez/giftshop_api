using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Products.Commands.Update
{
    public sealed class UpdateProductCommandHandlerValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandHandlerValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(p => p.Product)
                .NotNull();

            var innerValidator = new UpdateProductModelValidator();
            RuleFor(p => p.Product)
                .SetValidator(innerValidator);
        }
    }
}
