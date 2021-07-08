using AutoMapper;
using GS.Application.Contracts.Identity;
using GS.Application.Models.Authentication;
using GS.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Authentication.Commands
{
    public sealed class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticationResponse>>
    {
        private readonly IAuthenticationService _authService;

        public AuthenticateCommandHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public async Task<Response<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _authService.AuthenticateAsync(new AuthenticationRequest { 
                Email = request.Email,
                Password = request.Password
            });
        }
    }
}
