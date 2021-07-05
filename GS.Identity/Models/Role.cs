using Microsoft.AspNetCore.Identity;
using System;

namespace GS.Identity.Models
{
    public class Role: IdentityRole<Guid>
    {
        public const string Admin = "Admin";
        public const string Terminal = "Terminal";
    }
}
