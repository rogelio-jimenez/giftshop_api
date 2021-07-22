using System;

namespace GS.Application.Features.Admin.ProductImages.Commands
{
    public class AddImagesModel
    {
        public string LabelName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid UserId { get; set; }
        public long ByteSize { get; set; }
        public Guid ProductId { get; set; }
    }
}