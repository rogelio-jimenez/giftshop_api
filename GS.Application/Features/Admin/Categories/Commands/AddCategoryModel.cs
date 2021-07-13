using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands
{
    public class AddCategoryModel : Entity, IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EnabledStatus Status { get; set; }
        public Guid UserId { get; set; }
    }
}
