using System.ComponentModel.DataAnnotations;

namespace GS.Application.Models.Authentication
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
    }
}