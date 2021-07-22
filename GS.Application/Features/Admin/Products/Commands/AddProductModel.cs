using GS.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace GS.Application.Features.Admin.Products.Commands
{
    public class AddProductModel : IStatus<EnabledStatus>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public EnabledStatus Status { get; set; }
#nullable enable
        public IEnumerable<IFormFile>? Images { get; set; }
#nullable disable

        // #nullable enable
        //         public ICollection<AddImageModel>? Images { get; set; }
        // #nullable disable
    }
}
