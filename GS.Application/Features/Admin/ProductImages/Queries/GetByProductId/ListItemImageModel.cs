using System;
using System.IO;

namespace GS.Application.Features.Admin.ProductImages.Queries.GetByProductId
{
    public class ListItemImageModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string LabelName { get; set; }
        public string RelativePath
        {
            get
            {
                return
                    Path.Combine(
                        Path.Combine(
                            Path.Combine(AppConstants.AssetsFolderName, AppConstants.ProductImagesFolderName),
                        ProductId.ToString()),
                    Name);
            }
        }
        public DateTime DateCreated { get; set; }

    }
}