using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands.Edit
{
    public class UpdateCategoryCommandValidator: AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Category).NotNull();

            var innerValidator = new UpdateCategoryModelValidator();
            RuleFor(c => c.Category)
                .SetValidator(innerValidator);
        }
    }
}
