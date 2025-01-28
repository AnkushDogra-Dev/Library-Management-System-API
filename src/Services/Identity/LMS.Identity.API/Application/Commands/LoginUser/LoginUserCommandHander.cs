// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using LMS.Identity.API.Application.DTOs;
// using LMS.Identity.API.Persistance;
// using LMS.Identity.API.Repository;
// using MediatR;

// namespace LMS.Identity.API.Application.Commands
// {
//     public class LoginUserCommandHander : IRequestHandler<LoginUserCommand, AuthToken?>
//     {
//         private readonly IIdentityRepository _IidentityRepository;

//         public LoginUserCommandHander(IIdentityRepository IidentityRepository)
//         {
//             _IidentityRepository = IidentityRepository;
//         }
//         public async Task<AuthToken?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
//         {
//             var token = await _IidentityRepository.LoginUser(request.Email, request.Password, cancellationToken);
//             if (token is not null)
//             {
//                 return new AuthToken(token);
//             }

//             return default;
//         }
//     }
// }