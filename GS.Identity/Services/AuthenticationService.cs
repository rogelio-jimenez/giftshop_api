using GS.Application.Contracts.Identity;
using GS.Application.Models.Authentication;
using GS.Application.Wrappers;
using GS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GS.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenGenerator _tokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings, TokenGenerator tokenGenerator, RefreshTokenGenerator refreshTokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _tokenGenerator = tokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            AuthenticationResponse response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = await GenerateToken(user),
                Email = user.Email,
                UserName = user.UserName,
                RefreshToken = _refreshTokenGenerator.GenerateToken(),
                ExpiresIn = _tokenGenerator.JwtSecurityToken.ValidTo
            };
            
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;

            return new Response<AuthenticationResponse>(response, $"User {response.UserName} Authenticated.");
        }

        public Task<Response<AuthenticationResponse>> RefreshTokenAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            return _tokenGenerator.GenerateToken(
                _jwtSettings.Key,
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                _jwtSettings.DurationInMins,
                claims);
        }

    }
}
