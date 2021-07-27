using GS.Application;
using GS.Application.Features.Admin.ProductImages.Commands.Add;
using GS.Application.Features.Admin.ProductImages.Commands.DeleteAllByProduct;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment _env;
        private readonly string ImagesFolderFullName;
        public ProductController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
            ImagesFolderFullName = Path.Combine(_env.WebRootPath, Path.Combine(AppConstants.AssetsFolderName, AppConstants.ProductImagesFolderName));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddProductModel model)
        {
            var userId = User.Identity.GetUserId();
            model.UserId = userId;
            var newProduct = await _mediator.Send(new AddProductCommand(model));

            if (newProduct.Data != null && (model.Images != null && model.Images.Count() > 0))
            {
                await _mediator.Send(new AddImagesCommand(newProduct.Data, userId, model.Images, ImagesFolderFullName));
            }

            return Ok(newProduct);
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
            var userId = User.Identity.GetUserId();
            var result = await _mediator.Send(new DeleteProductCommand(id, userId));
            if (result.Succeeded)
            {
                await _mediator.Send(new DeleteAllByProductCommand(id, ImagesFolderFullName));
            }
            return Ok(result.Data);
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
