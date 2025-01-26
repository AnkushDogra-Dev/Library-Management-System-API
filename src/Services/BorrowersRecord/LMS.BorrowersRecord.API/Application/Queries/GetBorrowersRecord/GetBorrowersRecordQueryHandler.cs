using AutoMapper;
using LMS.Application.Common.Extensions;
using LMS.BorrowersRecord.API.Application.DTOs;
using LMS.BorrowersRecord.API.Application.Queries;
using LMS.BorrowersRecord.API.Repository;
using MediatR;


namespace LMS.BorrowersRecord.API.Application.Queries
{
    public record GetBorrowersRecordQueryHandler : IRequestHandler<GetBorrowersRecordQuery, PagedList<BorrowersRecordDTO>> {
        private readonly IBorrowerRepository _iBorrowersRepository;
        private readonly IMapper _mapper;


        public GetBorrowersRecordQueryHandler(IBorrowerRepository iBorrowersRepository, IMapper mapper)
        {
            _iBorrowersRepository = iBorrowersRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<BorrowersRecordDTO>> Handle(GetBorrowersRecordQuery request, CancellationToken cancellationToken)
        {
            var books = await _iBorrowersRepository.GetBorrowersAsync(request.search, request.page, request.pageSize,cancellationToken);

            return _mapper.Map<PagedList<BorrowersRecordDTO>>(books);
        }
    }
}
