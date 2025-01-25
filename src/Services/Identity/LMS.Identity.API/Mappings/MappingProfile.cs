//using AutoMapper;
//using LMS.Identity.API.Application.Commands;
//using LMS.Identity.API.Entities;

//namespace LMS.Identity.API.Mappings
//{
//	public class MappingProfile : Profile
//	{
//		public MappingProfile()
//		{
//			//This will map the data from Product Entity to ProductDto Entity
//			CreateMap<User, UserDto>()
//				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

//			//This will map the data from GetProductQuery to Product Entity
//			CreateMap<GetAllUsersQuery, User>();

//			CreateMap<UpsertUserCommand, User>();
//			 CreateMap<User, UserDto>();
//		}
//	}
//}