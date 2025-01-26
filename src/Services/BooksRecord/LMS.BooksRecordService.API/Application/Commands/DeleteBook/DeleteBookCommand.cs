using MediatR;

namespace LMS.BooksRecordService.API.Application.Commands
{
    public readonly record struct DeleteBookCommand(int BookId) : IRequest;
}
