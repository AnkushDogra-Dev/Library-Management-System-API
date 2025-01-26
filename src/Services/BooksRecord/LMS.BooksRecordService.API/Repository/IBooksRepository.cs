using LMS.Application.Common.Extensions;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Entities;

namespace LMS.BooksRecordService.API.Repository
{
	public interface IBooksRepository
	{
		Task<PagedList<Book>> GetBooksAsync(string? search, int page, int pageSize, CancellationToken cancellationToken);

		Task UpdateBookAsync(int bookId, string title, string author, string publisher, DateTime publicationDate, CancellationToken cancellationToken);
		Task<int> AddBookAsync(string title, string author, string publisher, DateTime publicationDate, CancellationToken cancellationToken);
		Task DeleteAsync(int bookId, CancellationToken cancellationToken);
		// Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);

		// Task DeleteAsync(Guid id);

		// Task<bool> UpdateEntitiesAsync(Product product,CancellationToken cancellationToken = default);

		// Task<bool> AddEntitiesAsync(Product product, CancellationToken cancellationToken = default);
	}
}
