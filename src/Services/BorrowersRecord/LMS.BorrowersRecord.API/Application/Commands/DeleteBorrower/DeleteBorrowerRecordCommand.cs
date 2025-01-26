using MediatR;

namespace LMS.BorrowersRecord.API.Application.Commands
{
    public readonly record struct DeleteBorrowerRecordCommand(int BorrowerId) : IRequest;
}
