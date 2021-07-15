using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Domain.Entities
{
    public class ProductWishList : Entity, IHaveUserCreated, IHaveDateCreated
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}
