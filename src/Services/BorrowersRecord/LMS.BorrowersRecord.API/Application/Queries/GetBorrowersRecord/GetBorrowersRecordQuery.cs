using LMS.Application.Common.Extensions;
using LMS.BorrowersRecord.API.Application.DTOs;
using MediatR;

namespace LMS.BorrowersRecord.API.Application.Queries
{
    public readonly record struct  GetBorrowersRecordQuery(string? search, int page, int pageSize) : IRequest<PagedList<BorrowersRecordDTO>>;
}