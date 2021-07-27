using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GS.Application.Models.Authentication
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string RefreshTokenKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int DurationInMins { get; set; }
        public int RefreshTokenExpirationInMins { get; set; }
    }
}
