using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Models.Category
{
    public class CategoryModel : IStatus<EnabledStatus>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnabledStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
