using LMS.Identity.API.Application.DTOs;
using MediatR;

namespace LMS.Identity.API.Application.Commands
{
    public readonly record struct LoginUserCommand : IRequest<AuthToken?>
    {
        public string Email {get; init;}
        public string Password {get; init;}
    }
}