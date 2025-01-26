using AutoMapper;
using LMS.Application.Common.Exceptions;
using LMS.BorrowersRecord.API.Application.DTOs;
using LMS.BorrowersRecord.API.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LMS.BorrowersRecord.API.Application.Queries
{
    public record GetBorrowerRecordByIdQueryHandler : IRequestHandler<GetBorrowerRecordByIdQuery, BorrowersRecordDTO>
    {

        private readonly BorrowerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBorrowerRecordByIdQueryHandler(BorrowerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BorrowersRecordDTO> Handle(GetBorrowerRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var borrower = await _dbContext.Borrowers.FirstOrDefaultAsync(b => b.Id == request.BorrowersRecordId, cancellationToken) ?? throw new NotFoundException($"Book with ID {request.BorrowersRecordId} not found.");

            return _mapper.Map<BorrowersRecordDTO>(borrower);
        }
    }
}