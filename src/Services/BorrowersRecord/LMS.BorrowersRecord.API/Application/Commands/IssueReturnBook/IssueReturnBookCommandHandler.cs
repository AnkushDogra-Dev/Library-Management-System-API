using LMS.BorrowersRecord.API.Repository;
using MediatR;

namespace LMS.BorrowersRecord.API.Application.Commands
{
    public record IssueReturnBookCommandHandler : IRequestHandler<IssueReturnBookCommand>
    {
        private readonly IBorrowerRepository _iBorrowerRepository;
        public IssueReturnBookCommandHandler(IBorrowerRepository iBorrowerRepository)
        {
            _iBorrowerRepository = iBorrowerRepository;

        }

        public async Task Handle(IssueReturnBookCommand request, CancellationToken cancellationToken)
        {
            // await "";
        }

    }
}