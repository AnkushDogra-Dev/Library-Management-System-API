using LMS.Application.Common;
using LMS.Identity.API.Application.Commands;
using LMS.Identity.API.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// update an existing Admin.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="command">user Details.</param>
        [HttpPut("login")]
        [Authorize]
        public async Task<IActionResult> LoginUser(UpsertUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
