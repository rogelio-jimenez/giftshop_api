using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Models.Authentication
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool IsExpired => DateTime.Now >= ExpiresIn;
        public DateTime Created { get; set; }
        public string CretedByIP { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
