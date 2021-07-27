using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GS.Application;
using GS.Application.Features.Admin.ProductImages.Commands.Add;
using GS.Application.Features.Admin.ProductImages.Commands.Delete;
using GS.Application.Features.Admin.ProductImages.Commands.DeleteAllByProduct;
using GS.Application.Features.Admin.ProductImages.Queries.GetByProductId;
using GS.Identity;
using GS.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GS.API.Controllers.GiftShopAdmin
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Role.Admin)]
    public class ImageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;
        private readonly string ImagesFolderFullName;

        public ImageController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
            ImagesFolderFullName = Path.Combine(_env.WebRootPath, Path.Combine(AppConstants.AssetsFolderName, AppConstants.ProductImagesFolderName));
        }

        [HttpPost("{productId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(Guid productId, [FromForm] IEnumerable<IFormFile> images)
        {
            var userId = User.Identity.GetUserId();
            return Ok(await _mediator.Send(new AddImagesCommand(productId, userId, images, ImagesFolderFullName)));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteImageCommand(id)));
        }

        [HttpDelete("product/{productId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveAllByProduct(Guid productId)
        {
            return Ok(await _mediator.Send(new DeleteAllByProductCommand(productId, ImagesFolderFullName)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByProduct([FromQuery] GetImagesPageQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}