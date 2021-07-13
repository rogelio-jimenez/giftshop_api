using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands.Add
{
    public class AddCategoryCommandValidator: AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(c => c.Category).NotNull();

            var innerValidator = new AddCategoryModelValidator();
            RuleFor(c => c.Category)
                .SetValidator(innerValidator);
        }
    }
}
