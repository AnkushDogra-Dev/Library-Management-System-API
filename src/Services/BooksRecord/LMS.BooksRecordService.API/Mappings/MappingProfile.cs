using AutoMapper;
using LMS.Application.Common.Extensions;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Entities;

namespace LMS.BooksRecordService.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<PagedList<Book>, PagedList<BookDTO>>();
        }
    }
}