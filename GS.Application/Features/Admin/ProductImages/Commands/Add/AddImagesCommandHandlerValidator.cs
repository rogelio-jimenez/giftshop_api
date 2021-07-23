using System;
using FluentValidation;

namespace GS.Application.Features.Admin.ProductImages.Commands.Add
{
    public class AddImagesCommandHandlerValidator : AbstractValidator<AddImagesCommand>
    {
        public AddImagesCommandHandlerValidator()
        {
            RuleFor(pi => pi.ProductId)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(pi => pi.UserId)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(pi => pi.ImageAssetsFolderPath)
                .NotEmpty()
                .NotNull();

            RuleFor(pi => pi.Images)
                .NotNull();

            RuleForEach(pi => pi.Images)
                .SetValidator(new FileImageValidator());
        }
    }
}