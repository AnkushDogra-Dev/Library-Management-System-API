using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Application.Common.Extensions;
using LMS.BooksRecordService.API.Application.Commands;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.BooksRecordService.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBookAsync(UpsertBookCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBookAsync(int bookId, UpsertBookCommand command)
        {
            command.SetId(bookId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<PagedList<BookDTO>> GetBooksAsync(string? search, int page, int pageSize)
        {
            var books = await _mediator.Send(new GetBooksQuery(search,page ,pageSize));
            return books;
        }
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBook(int bookId)
        {

            var query = new GetBookByIdQuery { BookId = bookId };
            var book = await _mediator.Send(query);
            return Ok(book);
        }

        [HttpDelete("{bookId}")]
        public async Task DeleteBookByIdAsync(int bookId)
        {
             await _mediator.Send(new DeleteBookCommand(bookId));
        }
    }
}
