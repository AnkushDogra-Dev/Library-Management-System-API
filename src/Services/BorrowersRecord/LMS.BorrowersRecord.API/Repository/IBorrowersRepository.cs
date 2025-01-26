using LMS.Application.Common.Extensions;
using LMS.BorrowersRecord.API.Entities;

namespace LMS.BorrowersRecord.API.Repository
{
	public interface IBorrowerRepository
	{
		Task<PagedList<Borrower>> GetBorrowersAsync(string? search, int page, int pageSize, CancellationToken cancellationToken);

		Task UpdateBorrowerAsync(int borrowerId ,string fullName, string emailAddress, string phoneNumber, CancellationToken cancellationToken);
		Task<int> AddBorrowerAsync(string fullName, string emailAddress, string phoneNumber, CancellationToken cancellationToken);
		Task DeleteBorrowerAsync(int borrowerId, CancellationToken cancellationToken);
		// Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);

		// Task DeleteAsync(Guid id);

		// Task<bool> UpdateEntitiesAsync(Product product,CancellationToken cancellationToken = default);

		// Task<bool> AddEntitiesAsync(Product product, CancellationToken cancellationToken = default);
	}
}
