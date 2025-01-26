using System.Diagnostics.CodeAnalysis;

namespace LMS.BooksRecordService.API.Application.DTOs
{
    [SuppressMessage(
        "Maintainability",
        "S101",
        Justification = "Need to Suppress we cannot change the value."
    )]
    public class BookDTO
    {
        public string Title { get; init; } = "";
        public string Author { get; init; } = "";
        public string Publisher { get; init; } = "";
        public DateTime PublicationDate { get; init; }
        public int AvailableCopies { get; init; }
    }
}
