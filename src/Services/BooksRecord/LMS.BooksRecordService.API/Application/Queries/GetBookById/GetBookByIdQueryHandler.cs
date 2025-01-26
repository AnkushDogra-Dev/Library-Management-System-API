using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Application.Common.Exceptions;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Entities;
using LMS.BooksRecordService.API.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LMS.BooksRecordService.API.Application.Queries.GetBookById
{
    public record GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {

        private readonly BooksDbContext _dbContext;
        public GetBookByIdQueryHandler(BooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken) ?? throw new NotFoundException($"Book with ID {request.BookId} not found.");
            return new BookDTO
            {
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublicationDate = book.PublicationDate,
                AvailableCopies = book.AvailableCopies
            };
        }
    }
}