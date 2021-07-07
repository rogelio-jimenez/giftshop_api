using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.Domain.Entities
{
    public class CartItem : Entity, IHaveUserCreated, IHaveDateCreated
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
