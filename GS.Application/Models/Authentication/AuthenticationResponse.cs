using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GS.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
