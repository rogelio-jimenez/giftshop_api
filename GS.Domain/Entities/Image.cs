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
        public Product Product { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public EnabledStatus Status { get; set; }
    }
}
