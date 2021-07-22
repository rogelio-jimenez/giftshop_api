using GS.Domain.Models;
using System;
using System.Collections.Generic;

namespace GS.Domain.Entities
{
    public class Product : Entity, IAuditableEntity, IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //[Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid UserId { get; set; }
        public Guid? UpdatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public EnabledStatus Status { get; set; }

#nullable enable
        public virtual ICollection<Image>? Images { get; set; }
#nullable disable
        //public virtual ICollection<ProductWishList> ProductWishLists { get; set; }
    }
}
