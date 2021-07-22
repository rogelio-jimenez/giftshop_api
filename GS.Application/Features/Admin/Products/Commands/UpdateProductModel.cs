using GS.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace GS.Application.Features.Admin.Products.Commands
{
    public class UpdateProductModel : IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public EnabledStatus Status { get; set; }
#nullable enable
        public ICollection<IFormFile>? Images { get; set; }
#nullable disable
        public Guid? UpdatedById { get; set; }
    }
}
