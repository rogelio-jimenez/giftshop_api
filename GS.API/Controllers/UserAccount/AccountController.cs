using GS.Application.Contracts;
using GS.Application.Contracts.Identity;
using GS.Application.Features.Authentication.Commands;
using GS.Application.Models.Authentication;
using GS.Identity;
using GS.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GS.API.Controllers.UserAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest model)
        {
            var result = await _mediator.Send(new AuthenticateCommand { Email = model.Email, Password = model.Password });
            return Ok(result);
        }

        // [HttpPost("refreshToken")]
        // [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshRequest)
        // {

        // }

    }
}
