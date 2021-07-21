using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Products.Commands.Delete
{
    public sealed class DeleteProductCommandHandlerValidator: AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandHandlerValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
