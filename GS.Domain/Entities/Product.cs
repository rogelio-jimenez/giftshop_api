using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Domain.Entities
{
    public class Product : Entity, IAuditableEntity, IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public EnabledStatus Status { get; set ; }
        public virtual ICollection<Image> Images { get; set; }

    }
}
