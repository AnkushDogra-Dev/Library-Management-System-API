using LMS.Application.Common.Exceptions;
using LMS.Application.Common.Extensions;
using LMS.BorrowersRecord.API.Entities;
using LMS.BorrowersRecord.API.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LMS.BorrowersRecord.API.Repository

{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly BorrowerDbContext _context;

        public BorrowerRepository(BorrowerDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddBorrowerAsync(string fullName, string emailAddress, string phoneNumber, CancellationToken cancellationToken)
        {
            var borrower = await _context.Borrowers.FirstOrDefaultAsync(b => b.EmailAddress == emailAddress && b.PhoneNumber == phoneNumber, cancellationToken: cancellationToken);
            
                borrower = new Borrower(fullName, emailAddress, phoneNumber);
                _context.Borrowers.Add(borrower);
                
            await _context.SaveChangesAsync(cancellationToken);

            return borrower.Id;
        }

        public async Task UpdateBorrowerAsync(int borrowerId ,string fullName, string emailAddress, string phoneNumber, CancellationToken cancellationToken)
        {

            var borrower = await _context.Borrowers.FirstOrDefaultAsync(b => b.Id == borrowerId, cancellationToken)
                ?? throw new NotFoundException(nameof(Borrower), borrowerId);
            borrower.UpdateBorrowerDetails(fullName, emailAddress, phoneNumber);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedList<Borrower>> GetBorrowersAsync(string? search, int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = _context.Borrowers.AsQueryable();
            if (search is not null)
            {
                query = query.Where(x => x.FullName.Contains(search));
            }
            return await query.OrderBy(x => x.Id).ToPagedListAsync(page, pageSize, cancellationToken = default);
        }

        public async Task DeleteBorrowerAsync(int borrowerId, CancellationToken cancellationToken)
        {
            var borrower = await _context.Borrowers.FirstOrDefaultAsync(b => b.Id == borrowerId, cancellationToken)
            ?? throw new NotFoundException(nameof(Borrower), borrowerId);

            _context.Borrowers.Remove(borrower);
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}



