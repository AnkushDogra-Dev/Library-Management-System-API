using LMS.Identity.API.Application.DTOs;
using MediatR;

namespace LMS.Identity.API.Application.Commands
{
    public readonly record struct LoginUserCommand(string Email, string Password) : IRequest<AuthToken?>;
}