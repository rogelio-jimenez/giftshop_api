using System;
using FluentValidation;

namespace GS.Application.Features.Admin.ProductImages.Commands
{
    public class AddImagesModelValidator : AbstractValidator<AddImagesModel>
    {
        public AddImagesModelValidator()
        {
            RuleFor(pi => pi.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64)
                .WithMessage("the length of {Propertyname} must be less or equal to {MaxLength}");

            RuleFor(pi => pi.LabelName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64)
                .WithMessage("the length of {Propertyname} must be less or equal to {MaxLength}");

            RuleFor(pi => pi.UserId)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(pi => pi.ByteSize)
                .GreaterThan(0)
                .LessThanOrEqualTo(AppConstants.ProductImageMaxLength)
                .WithMessage("File size is larger than allowed.");


        }
    }
}