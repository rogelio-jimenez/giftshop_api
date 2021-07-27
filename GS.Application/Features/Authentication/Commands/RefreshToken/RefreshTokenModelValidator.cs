using FluentValidation;

namespace GS.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenModelValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenModelValidator()
        {
            RuleFor(rt => rt.RefreshToken)
                .NotNull()
                .NotEmpty();
        }
    }
}