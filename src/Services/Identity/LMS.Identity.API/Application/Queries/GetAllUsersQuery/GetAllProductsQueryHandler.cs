//using AuthenticationMicroservice.Entities;
//using AuthenticationMicroservice.Interfaces;
//using AutoMapper;
//using MediatR;

//namespace LMS.Identity.API.Application.Commands
//{
//	public record GetAllProductsQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
//	{
//		private readonly IMapper _mapper;
//		private readonly IAuth _repository;

//		public GetAllProductsQueryHandler(IMapper mapper, IAuth repository)
//		{
//			_mapper = mapper;
//			_repository=repository;
//		}

//		public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
//		{
//			var users = await _repository.GetAllUsersAsync(cancellationToken);
//            if (users == null || !users.Any())
//            {
//               return new List<UserDto>();
//            }
//            return _mapper.Map<List<UserDto>>(users);
//		}
//	}
//}
