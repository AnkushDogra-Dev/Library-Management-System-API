using LMS.BorrowersRecord.API.Application.DTOs;
using MediatR;

namespace LMS.BorrowersRecord.API.Application.Queries
{
    public class GetBorrowerRecordByIdQuery : IRequest<BorrowersRecordDTO>
    {
        public int BorrowersRecordId { get; init; }
    }
}