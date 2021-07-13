using AutoMapper;
using GS.Application.Features.Admin.Categories.Commands;
using GS.Application.Features.Admin.Categories.Commands.Add;
using GS.Application.Features.Admin.Categories.Commands.Delete;
using GS.Application.Features.Admin.Categories.Commands.Edit;
using GS.Identity;
using GS.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GS.API.Controllers.GiftShopAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Role.Admin)]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryModel model)
        {
            model.UserId = User.Identity.GetUserId();
            return Ok(await _mediator.Send(new AddCategoryCommand(model)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, UpdateCategoryModel model)
        {
            model.Id = id;
            model.UpdatedById = User.Identity.GetUserId();
            return Ok(await _mediator.Send(new UpdateCategoryCommand(model)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteCategoryCommand(id)));
        }
    }
}
