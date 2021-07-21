using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Products.Queries
{
    public class ProductModel : Entity, IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public EnabledStatus Status { get; set; }
        public DateTime DateCreated { get; set; }

    
    }
}
