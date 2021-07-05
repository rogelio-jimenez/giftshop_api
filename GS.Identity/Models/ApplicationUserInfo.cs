using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Identity.Models
{
    public class ApplicationUserInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public long? ExpiresIn { get; set; }
    }
}
