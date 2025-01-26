using LMS.BorrowersRecord.API.Repository;
using MediatR;

namespace LMS.BorrowersRecord.API.Application.Commands
{
    public record UpsertBorrowerRecordCommandHandler : IRequestHandler<UpsertBorrowerRecordCommand, int?>
    {
        private readonly IBorrowerRepository _iBorrowerRepository;
        public UpsertBorrowerRecordCommandHandler(IBorrowerRepository iBorrowerRepository)
        {
            _iBorrowerRepository = iBorrowerRepository;

        }

        public async Task<int?> Handle(UpsertBorrowerRecordCommand request, CancellationToken cancellationToken)
        {
            if (request.BorrowerId > 0)
            {
                await _iBorrowerRepository.UpdateBorrowerAsync(request.BorrowerId, request.FullName, request.EmailAddress,
                                     request.PhoneNumber, cancellationToken);
                return default;
            }
            else
            {
                return await _iBorrowerRepository.AddBorrowerAsync(request.FullName, request.EmailAddress, request.PhoneNumber, cancellationToken);
            }
        }
    }
}