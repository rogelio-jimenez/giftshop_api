using GS.Domain.Models;
using System;

namespace GS.Domain.Entities
{
    public class Category : Entity, IAuditableEntity, IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public EnabledStatus Status { get; set; }
        public Guid UserId { get; set; }
        public Guid? UpdatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        
    }
}
