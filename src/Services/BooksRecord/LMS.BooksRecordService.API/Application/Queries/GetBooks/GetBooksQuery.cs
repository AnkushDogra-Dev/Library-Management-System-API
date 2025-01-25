using LMS.Application.Common.Extensions;
using LMS.BooksRecordService.API.Application.DTOs;
using MediatR;

namespace LMS.BooksRecordService.API.Application.Queries
{
    public readonly record struct  GetBooksQuery(string? search, int page, int pageSize) : IRequest<PagedList<BookDTO>>;
}