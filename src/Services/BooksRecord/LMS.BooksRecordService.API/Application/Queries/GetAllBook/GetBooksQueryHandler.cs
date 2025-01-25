using AutoMapper;
using LMS.Application.Common.Extensions;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Persistance;
using LMS.BooksRecordService.API.Repository;
using MediatR;


namespace LMS.BooksRecordService.API.Application.Queries
 {
    public record GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedList<BookDTO>> {
        private readonly IBooksRepository _iBooksRepository;
        private readonly IMapper _mapper;


        public GetBooksQueryHandler(IBooksRepository iBooksRepository, IMapper mapper)
        {
            _iBooksRepository = iBooksRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _iBooksRepository.GetBooksAsync(request.search, request.page, request.pageSize,cancellationToken);

            return _mapper.Map<PagedList<BookDTO>>(books);
        }
    }
}
