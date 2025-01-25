using LMS.Application.Common.Entities;

namespace LMS.BooksRecordService.API.Entities
{
    public class Book : SqlEntity
    {
        public Book() { }

        public string Title { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public string Publisher { get; private set; } = string.Empty;
        public DateTime PublicationDate { get; private set; }
        public int AvailableCopies { get; private set; }

        public Book(string title, string author, string publisher, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            PublicationDate = publicationDate;
        }

        public void RemoveBook()
        {
            AvailableCopies--;
        }

        public void AddBook()
        {
            AvailableCopies++;
        }

        public void UpdateBookDetails(string? title, string? author, string? publisher, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            PublicationDate = publicationDate;
        }
    }
}
