using System.Threading;
using LMS.Application.Common.Exceptions;
using LMS.Application.Common.Extensions;
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

        public async Task<int> AddBookAsync(string title, string author, string publisher, DateTime publicationDate, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == title && b.Author == author, cancellationToken: cancellationToken);
            // agr isko usi title and author ki book db me mill jati he to bo count increase krega naki new book add krega...
            if (book is not null)
            {
                book.AddBook(); //It will increase the available count of the book
            }
            else
            {
                book = new Book(title, author, publisher, DateTime.UtcNow);
                _context.Books.Add(book);
            }
            await _context.SaveChangesAsync(cancellationToken);

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, string title, string author, string publisher, DateTime publicationDate, CancellationToken cancellationToken)
        {

            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken)
                ?? throw new NotFoundException(nameof(Book), bookId);
            book.UpdateBookDetails(title, author, publisher, publicationDate);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedList<Book>> GetBooksAsync(string? search, int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = _context.Books.AsQueryable();
            if (search!=null)
            {
                query = query.Where(x => x.Title.Contains(search));
            }
            return await query.OrderBy(x => x.Id).ToPagedListAsync(page, pageSize, cancellationToken = default);
        }

        public async Task DeleteAsync(int bookId, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken)
            ?? throw new NotFoundException(nameof(Book), bookId);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}



