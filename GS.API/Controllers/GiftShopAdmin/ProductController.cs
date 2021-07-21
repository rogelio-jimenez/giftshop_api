using GS.Application.Features.Admin.Products.Commands;
using GS.Application.Features.Admin.Products.Commands.Add;
using GS.Application.Features.Admin.Products.Commands.Delete;
using GS.Application.Features.Admin.Products.Commands.Update;
using GS.Application.Features.Admin.Products.Queries.GetById;
using GS.Application.Features.Admin.Products.Queries.GetPage;
using GS.Identity;
using GS.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.API.Controllers.GiftShopAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Role.Admin)]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddProductModel model)
        {
            model.UserId = User.Identity.GetUserId();
            return Ok(await _mediator.Send(new AddProductCommand(model)));
        }


        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateProductModel model)
        {
            model.UpdatedById = User.Identity.GetUserId();
            return Ok(await _mediator.Send(new UpdateProductCommand(id, model)));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand(id)));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetProductQuery(id)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPage([FromQuery] GetProductPageQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
