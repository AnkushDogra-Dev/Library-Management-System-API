using LMS.BorrowersRecord.API.Repository;
using MediatR;

namespace LMS.BorrowersRecord.API.Application.Commands
{
    public record DeleteBorrowerRecordCommandHandler : IRequestHandler<DeleteBorrowerRecordCommand>
    {
        private readonly IBorrowerRepository _iBorrowerRepository;
        public DeleteBorrowerRecordCommandHandler(IBorrowerRepository iBorrowerRepository)
        {
            _iBorrowerRepository = iBorrowerRepository;
        }

        public async Task Handle(DeleteBorrowerRecordCommand request, CancellationToken cancellationToken)
        {
            await _iBorrowerRepository.DeleteBorrowerAsync(request.BorrowerId, cancellationToken);
        }
    }
}