// using Common.Constants;
// using LMS.Identity.API.Interfaces;
// using MediatR;

// namespace LMS.Identity.API.Application.Commands {
//     public record UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string> {
//         private readonly IdentityService _repository;

//         public UserLoginCommandHandler(Identity repository)
//         {
//             _repository = repository;
//         }

//         public Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
//         {
//             var data = new LoginRequest(request.Email, request.Password);
//             var response = _repository.Login(data) ?? throw new Exception(Constant.InvalidData);
//             return response;
//         }
//     }
// }
