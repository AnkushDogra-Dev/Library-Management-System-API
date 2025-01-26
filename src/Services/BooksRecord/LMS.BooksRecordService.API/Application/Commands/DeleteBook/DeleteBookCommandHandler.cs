using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using LMS.Application.Common.Exceptions;
using LMS.BooksRecordService.API.Entities;
using LMS.BooksRecordService.API.Persistance;
using LMS.BooksRecordService.API.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LMS.BooksRecordService.API.Application.Commands.DeleteBook
{
    public record DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksRepository _iBooksRepository;
        public DeleteBookCommandHandler(IBooksRepository iBooksRepository)
        {
            _iBooksRepository = iBooksRepository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _iBooksRepository.DeleteAsync(request.BookId, cancellationToken);
        }
    }
}