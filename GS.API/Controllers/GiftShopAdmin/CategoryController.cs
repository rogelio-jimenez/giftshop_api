using AutoMapper;
using GS.Application.Features.Admin.Categories.Commands;
using GS.Application.Features.Admin.Categories.Commands.Add;
using GS.Application.Features.Admin.Categories.Commands.Delete;
using GS.Application.Features.Admin.Categories.Commands.Edit;
using GS.Application.Features.Admin.Categories.Queries.GetAll;
using GS.Application.Features.Admin.Categories.Queries.GetById;
using GS.Application.Features.Admin.Categories.Queries.GetPage;
using GS.Application.Models.Category;
using GS.Application.Queries;
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

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CategoryModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdQuery(id)));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<CategoryModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPage([FromQuery] GetCategoryPageQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(AllItemsResult<CategoryModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddCategoryModel model)
        {
            model.UserId = User.Identity.GetUserId();
            return Ok(await _mediator.Send(new AddCategoryCommand(model)));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryModel model)
        {
            model.UpdatedById = User.Identity.GetUserId();
            return Ok(await _mediator.Send(new UpdateCategoryCommand(id, model)));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteCategoryCommand(id, User.Identity.GetUserId())));
        }
    }
}
