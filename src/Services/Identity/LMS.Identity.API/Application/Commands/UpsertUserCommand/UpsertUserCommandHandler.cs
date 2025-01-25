//using LMS.Identity.API.Entities;
//using LMS.Identity.API.Interfaces;
//using MediatR;

//namespace LMS.Identity.API.Application.Commands
//{
//   public record UpsertUserCommandHandler : IRequestHandler<UpsertUserCommand, string>
//   {
//       private readonly IIdentity _repository;

//       public UpsertUserCommandHandler(IIdentity repository)
//       {
//           _repository = repository;
//       }

//       public async Task<string> Handle(
//           UpsertUserCommand request,
//           CancellationToken cancellationToken
//       )
//       {
//           var existingUser = await _repository.GetByIdAsync(request.Id);

//           if (existingUser is not null)
//           {
//               existingUser.Update(request.Email, request.Password);

//               await _repository.UpdateAsync(existingUser);

//               return existingUser.Id;
//           }
//           //else
//           //{
//           //    var user = new User(request.Email, request.Password);

//           //    return await _repository.AddUser(user);
//           //}
//       }
//   }
//}
