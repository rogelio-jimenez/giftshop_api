using GS.Application.Wrappers;
using GS.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Features.Admin.Categories.Commands
{
    public class UpdateCategoryModel: IHaveUserUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? UpdatedById { get; set; }
    }
}
