using AutoMapper;
using GS.Application.Common.Pagination;
using GS.Application.Features.Admin.Categories.Commands;
using GS.Application.Features.Admin.Categories.Commands.Add;
using GS.Application.Features.Admin.Categories.Commands.Delete;
using GS.Application.Features.Admin.Categories.Commands.Edit;
using GS.Application.Features.Admin.Categories.Queries.GetById;
using GS.Application.Features.Admin.Categories.Queries.GetPage;
using GS.Application.Models.Category;
using GS.Identity;
using GS.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdQuery(id)));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListResponseModel<CategoryModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPage([FromQuery] GetCategoryPageQuery query)
        {
            return Ok(await _mediator.Send(query));
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
