using GS.Application.Models.Authentication;
using GS.Application.Wrappers;
using System.Threading.Tasks;

namespace GS.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        //Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
