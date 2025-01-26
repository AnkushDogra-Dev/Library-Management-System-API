using LMS.BooksRecordService.API.Application.DTOs;
using MediatR;

namespace LMS.BooksRecordService.API.Application.Queries
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public int BookId { get; init; }
    }
}