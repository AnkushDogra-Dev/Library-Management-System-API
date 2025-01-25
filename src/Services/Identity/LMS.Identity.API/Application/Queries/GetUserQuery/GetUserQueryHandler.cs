//using AuthenticationMicroservice.Entities;
//using AuthenticationMicroservice.Interfaces;
//using AuthenticationMicroservice.Queries;
//using AutoMapper;
//using Common;
//using MediatR;

//namespace LMS.Identity.API.Application.Commands
//{
//	public record GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
//	{
//		private readonly IMapper _mapper;
//		private readonly IAuth _repository;

//		public GetUserQueryHandler(IMapper mapper, IAuth repository)
//		{
//			_mapper = mapper;
//			_repository = repository;
//		}

//		public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
//		{
//			var user = await _repository.GetByIdAsync(request.id);
//			if (user is null)
//			{
//				throw ValidationCodes.ValidationException("User", ValidationCodes.UserNotFound);
//			}
//			return _mapper.Map<UserDto>(user);
//		}
//	}
//}
