using LMS.Application.Common.Exceptions;
using LMS.BooksRecordService.API.Entities;
using LMS.BooksRecordService.API.Persistance;
using LMS.BooksRecordService.API.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LMS.BooksRecordService.API.Application.Commands
{
    public record UpsertBookCommandHandler : IRequestHandler<UpsertBookCommand, int?>
    {
        private readonly BooksDbContext _dbContext;
        private readonly IBooksRepository _iBooksRepository;

        public UpsertBookCommandHandler(IBooksRepository iBooksRepository)
        {
            _iBooksRepository = iBooksRepository;

        }

        public async Task<int?> Handle(UpsertBookCommand request, CancellationToken cancellationToken)
        {
            if (request.BookId > 0)
            {
                await _iBooksRepository.UpdateBookAsync(request.BookId, request.Title, request.Author,
                                     request.Publisher, request.PublicationDate, cancellationToken);
                return default;
            }
            else
            {
                return await _iBooksRepository.AddBookAsync(request.Title, request.Author, request.Publisher, request.PublicationDate, cancellationToken);
            }
        }
    }
}