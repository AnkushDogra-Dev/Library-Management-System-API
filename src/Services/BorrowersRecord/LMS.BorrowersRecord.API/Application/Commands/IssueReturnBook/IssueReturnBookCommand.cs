using MediatR;

namespace LMS.BorrowersRecord.API.Application.Commands
{
    public readonly record struct IssueReturnBookCommand(int BorrowerId, int BookId) : IRequest
    { }
}