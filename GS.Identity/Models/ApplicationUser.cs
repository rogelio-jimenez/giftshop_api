using GS.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace GS.Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>, IStatus<EnabledStatus>
    {
        public EnabledStatus Status { get; set; }
    }
}
