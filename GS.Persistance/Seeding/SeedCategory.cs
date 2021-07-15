using GS.Application.Contracts;
using GS.Domain.Entities;
using GS.Domain.Models;
using GS.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.Persistance.Seeding
{
    public class SeedCategory
    {
        private readonly Guid _userAdminId;
        private readonly IDateTime _dateTime;
        public List<Category> Items { get; set; }


        public SeedCategory(Guid userAdminId, IDateTime dateTime)
        {
            this._userAdminId = userAdminId;
            this._dateTime = dateTime;
            this.Items = Categories;
        }

        private List<Category> Categories
        {
            get
            {
                return new List<Category>() {
                    new Category { 
                        Name = "Tools",
                        Description = "General Tools",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Construction",
                        Description = "General Construction",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Sports & Fitness",
                        Description = "General for Sports and fintness",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Home & Insdustry",
                        Description = "General for home and insdustries",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Game & Toys",
                        Description = "General games and toys",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Babies",
                        Description = "General for babies",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Technology",
                        Description = "General for technology",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Meals & Drinks",
                        Description = "General for meal and drinks",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Animals & Pets",
                        Description = "General stuff for animals and pets",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Art",
                        Description = "General for arts",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Vehicles & Motorbikes",
                        Description = "General tools for vehicles and motorbikes",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Self Care",
                        Description = "Stuff for self caring",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Music",
                        Description = "Good Music",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Clothes",
                        Description = "General for Clothes",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    },
                    new Category {
                        Name = "Audio & Video",
                        Description = "Good tools for audio and video",
                        Status = EnabledStatus.Enabled,
                        UserId = _userAdminId
                    }
                };
            }
        }
    }
}
