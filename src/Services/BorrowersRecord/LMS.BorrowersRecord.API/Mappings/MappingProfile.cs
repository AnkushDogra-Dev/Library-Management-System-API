using AutoMapper;
using LMS.Application.Common.Extensions;
using LMS.BorrowersRecord.API.Application.DTOs;
using LMS.BorrowersRecord.API.Entities;

namespace LMS.BorrowersRecord.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Borrower, BorrowersRecordDTO>();
            CreateMap<PagedList<Borrower>, PagedList<BorrowersRecordDTO>>();

        }
    }
}