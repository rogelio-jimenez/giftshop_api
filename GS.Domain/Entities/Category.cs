using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Domain.Entities
{
    public class Category : Entity, IAuditableEntity, IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public EnabledStatus Status { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        
    }
}
