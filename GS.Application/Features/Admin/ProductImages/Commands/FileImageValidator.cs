using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace GS.Application.Features.Admin.ProductImages.Commands
{
    public class FileImageValidator : AbstractValidator<IFormFile>
    {
        public FileImageValidator()
        {
            RuleFor(x => x.Length)
                .NotNull()
                .LessThanOrEqualTo(AppConstants.ProductImageMaxLength)
                .WithMessage("File size is larger than allowed.");

            RuleFor(x => x.Name)
                .NotNull()
                .MaximumLength(64)
                .WithMessage("{PropertyName} must be less than {MaxLength} characters.");

            RuleFor(x => x.ContentType)
                .NotNull()
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("Invalid file format.");
        }
    }
}