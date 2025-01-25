using LMS.Application.Common.Extensions;
using LMS.BooksRecordService.API.Application.DTOs;
using LMS.BooksRecordService.API.Entities;
using LMS.BooksRecordService.API.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LMS.BooksRecordService.API.Repository

{
	public class BooksRepository : IBooksRepository
	{
		private readonly BooksDbContext _context;

        public BooksRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Book>> GetBooksAsync(string? search, int page , int pageSize,CancellationToken cancellationToken)
        {
            var query =  _context.Books.AsQueryable();
            return await query.OrderBy(x=> x.Id).ToPagedListAsync(page, pageSize);
        }
    }
}



