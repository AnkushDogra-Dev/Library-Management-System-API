using LMS.Application.Common.Extensions;
using LMS.BorrowersRecord.API.Application.Commands;
using LMS.BorrowersRecord.API.Application.DTOs;
using LMS.BorrowersRecord.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.BorrowersRecord.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BorrowersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> AddBorrowerAsync(UpsertBorrowerRecordCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{borrowerId}")]
        public async Task<IActionResult> UpdateBorrowerAsync(int borrowerId, UpsertBorrowerRecordCommand command)
        {
            command.SetId(borrowerId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<PagedList<BorrowersRecordDTO>> GetBorrowersAsync(string? search, int page, int pageSize)
        {
            var books = await _mediator.Send(new GetBorrowersRecordQuery(search,page ,pageSize));
            return books;
        }

        [HttpGet("{borrowerId}")]
        public async Task<IActionResult> GetBorrower(int borrowerId)
        {

            var query = new GetBorrowerRecordByIdQuery { BorrowersRecordId = borrowerId };
            var book = await _mediator.Send(query);
            return Ok(book);
        }

        [HttpDelete("{borrowerId}")]
        public async Task DeleteBorrowerByIdAsync(int borrowerId)
        {
             await _mediator.Send(new DeleteBorrowerRecordCommand(borrowerId));
        }
    }
}
