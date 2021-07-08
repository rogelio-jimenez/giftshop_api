using GS.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GS.Application.Models.Authentication
{
    public abstract class EmailModelBase
    {
        [Required]
        [StringLength(AppConstants.EmailLength)]
        [EmailAddress]
        public virtual string Email { get; set; }
    }
}
