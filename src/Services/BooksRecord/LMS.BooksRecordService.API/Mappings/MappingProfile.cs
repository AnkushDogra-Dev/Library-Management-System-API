using AutoMapper;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Entities;

namespace LMS.BooksRecordService.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}