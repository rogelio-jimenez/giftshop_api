using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GS.Application.Models.Authentication
{
    public class AuthenticationRequest : EmailModelBase
    {
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
    }
}   