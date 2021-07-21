using GS.Domain.Entities;
using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Persistance.Seeding
{
    public class SeedProduct
    {
        private readonly Guid _userAdminId;
        public List<Product> Items { get; set; }

        public SeedProduct(Guid userAdmin)
        {
            _userAdminId = userAdmin;
            Items = Products;
        }

        private List<Product> Products
        {
            get
            {
                return new List<Product> { 
                    new Product { 
                        UserId = this._userAdminId,
                        CategoryId = Guid.Parse("221BC6A8-1A75-4C1D-A6CA-08D94AE0D5C4"),
                        Name = "Electric Guitar (Fender)",
                        Description = "The best of electric guitars.",
                        UpdatedById = this._userAdminId,
                        Price = 100,
                        Status = EnabledStatus.Enabled
                    },
                    new Product {
                        UserId = this._userAdminId,
                        CategoryId = Guid.Parse("221BC6A8-1A75-4C1D-A6CA-08D94AE0D5C4"),
                        Name = "Fender Drums",
                        Description = "This drum is awesome.",
                        UpdatedById = this._userAdminId,
                        Price = 100,
                        Status = EnabledStatus.Enabled
                    },
                    new Product {
                        UserId = this._userAdminId,
                        CategoryId = Guid.Parse("C487A972-31FF-452C-A6C5-08D94AE0D5C4"),
                        Name = "Wine",
                        Description = "Red wine",
                        UpdatedById = this._userAdminId,
                        Price = 100,
                        Status = EnabledStatus.Enabled
                    },
                    new Product {
                        UserId = this._userAdminId,
                        CategoryId = Guid.Parse("C487A972-31FF-452C-A6C5-08D94AE0D5C4"),
                        Name = "Coors Light Beer",
                        Description = "a nice beer.",
                        UpdatedById = this._userAdminId,
                        Price = 100,
                        Status = EnabledStatus.Enabled
                    },
                    new Product {
                        UserId = this._userAdminId,
                        CategoryId = Guid.Parse("5D315E98-0768-46D2-A6CB-08D94AE0D5C4"),
                        Name = "Dbz T-Shirt Male",
                        Description = "Dragon ball Z cloth",
                        UpdatedById = this._userAdminId,
                        Price = 100,
                        Status = EnabledStatus.Enabled
                    },
                    new Product {
                        UserId = this._userAdminId,
                        CategoryId = Guid.Parse("5D315E98-0768-46D2-A6CB-08D94AE0D5C4"),
                        Name = "DC Shoes",
                        Description = "For professional skaters.",
                        UpdatedById = this._userAdminId,
                        Price = 100,
                        Status = EnabledStatus.Enabled
                    }
                };
            }
        }
    }
}
