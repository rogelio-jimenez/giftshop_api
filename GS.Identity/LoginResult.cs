﻿namespace GS.Identity
{
    public enum LoginStatus
    {
        Failed = 0,
        Inactive = 1,
        NotConfirmed = 2,
        RequiresTwoFactor = 3,
        IsLockedOut = 4,
        PasswordExpired = 5,
        Success = 200,
        NotAllowed = 401
    }
    public class LoginResult
    {
        public LoginStatus Status { get; set; }
    }
}
