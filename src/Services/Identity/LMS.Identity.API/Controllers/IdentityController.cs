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

        //        /// <summary>
        //        /// Login the user
        //        /// </summary>
        //        /// <param name="command">Login Details</param>
        //        [HttpPost("login")]
        //        public async Task<string> Login(UserLoginCommand command)
        //        {
        //            var token = await _mediator.Send(command);
        //            return token;
        //        }

        //        /// <summary>
        //        /// Add new user in Db
        //        /// </summary>
        //        /// <param name="command">user Details to add</param>
        //        [HttpPost("addUser")]
        //        public async Task<IActionResult> AddUser(UpsertUserCommand command)
        //        {
        //            var addedUserId = await _mediator.Send(command);
        //            return Ok(addedUserId);
        //        }

        /// <summary>
        /// update an existing Admin.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="command">user Details.</param>
        [HttpPut("Sign-In")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAsync(UpsertUserCommand command)
        {
            // command.SetId(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        //        /// <summary>
        //        /// Get All Users from Database
        //        /// </summary>
        //        [HttpGet]
        //        [Authorize]
        //        public async Task<List<UserDto>> GetAllUsersAsync()
        //        {
        //            var products = await _mediator.Send(new GetAllUsersQuery());
        //            return products;
        //        }

        //        /// <summary>
        //        /// Get Details of a User
        //        /// </summary>
        //        /// <param name="id">user id</param>
        //        [HttpGet("{id}")]
        //        public async Task<UserDto> GetUserByIdAsync(Guid id)
        //        {
        //            var user = await _mediator.Send(new GetUserQuery(id));
        //            return user;
        //        }

        //        /// <summary>
        //        /// Delete an existing user.
        //        /// </summary>
        //        /// <param name="id">user id</param>
        //        [HttpDelete("{id}")]
        //        [Authorize]
        //        public async Task<string> DeleteUserAsync(Guid id)
        //        {
        //            return await _mediator.Send(new DeleteUserCommand { Id = id });
        //        }
    }
}
