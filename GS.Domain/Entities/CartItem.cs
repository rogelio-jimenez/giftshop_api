using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.Domain.Entities
{
    public class CartItem : IHaveUserCreated, IHaveDateCreated
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
