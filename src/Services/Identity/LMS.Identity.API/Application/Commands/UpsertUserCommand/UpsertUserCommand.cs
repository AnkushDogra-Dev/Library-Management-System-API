using MediatR;
using LMS.Application.Common;

namespace LMS.Identity.API.Application.Commands {
    public record UpsertUserCommand : IRequest<string> {

        /// <summary>
        /// Email of User
        /// </summary>
        public string Email { get; init; } = string.Empty;

        /// <summary>
        /// Password of User
        /// </summary>
        public string Password { get; init; } = string.Empty;
    }
}
