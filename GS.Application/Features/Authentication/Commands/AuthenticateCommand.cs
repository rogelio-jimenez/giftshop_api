using GS.Application.Models.Authentication;
using GS.Application.Wrappers;
using MediatR;

namespace GS.Application.Features.Authentication.Commands
{
    public class AuthenticateCommand: AuthenticationRequest, IRequest<Response<AuthenticationResponse>>
    {

    }
}
