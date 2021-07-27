using GS.Application.Models.Authentication;
using Microsoft.Extensions.Options;

namespace GS.Identity.Services
{
    public class RefreshTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly TokenGenerator _tokenGenerator;

        public RefreshTokenGenerator(IOptions<JwtSettings> jwtSettings, TokenGenerator tokenGenerator)
        {
            _jwtSettings = jwtSettings.Value;
            _tokenGenerator = tokenGenerator;
        }

        public string GenerateToken()
        {
            return _tokenGenerator.GenerateToken(
                _jwtSettings.RefreshTokenKey,
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                _jwtSettings.RefreshTokenExpirationInMins);
        }

    }
}