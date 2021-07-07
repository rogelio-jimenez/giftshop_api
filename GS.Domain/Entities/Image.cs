using GS.Domain.Models;
using System;

namespace GS.Domain.Entities
{
    public class Image : Entity, IAuditableEntity, IStatus<EnabledStatus>
    {
        public string LabelName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid UserId { get; set; }
        public Guid? UpdatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public EnabledStatus Status { get; set; }
    }
}
