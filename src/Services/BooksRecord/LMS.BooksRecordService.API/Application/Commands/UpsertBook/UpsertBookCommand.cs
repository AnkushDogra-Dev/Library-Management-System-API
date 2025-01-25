using MediatR;
using System.Text.Json.Serialization;

namespace LMS.BooksRecordService.API.Application.Commands
{
    public record UpsertBookCommand : IRequest<int>
    {
        [JsonIgnore]
        public int BookId { get; set; }
        public string? Title { get; init; }
        public string? Author { get; init; }
        public string? Publisher { get; init; }
        public DateTime PublicationDate { get; init; }
        
        public void SetId(int bookId)
        {
            BookId = bookId;
        }
    }
}