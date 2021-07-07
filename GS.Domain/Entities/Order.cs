using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Domain.Entities
{
    public class Order : Entity, IHaveUserCreated, IHaveDateCreated
    {
        public Guid CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
