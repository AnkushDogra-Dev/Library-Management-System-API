using System.Diagnostics.CodeAnalysis;
using LMS.BorrowersRecord.API.Entities;

namespace LMS.BorrowersRecord.API.Application.DTOs
{
    public record BorrowersRecordDTO
    {
        public string FullName { get; init; } = "";
        public string EmailAddress { get; init; } = "";
        public string PhoneNumber { get; init; } = "";
        public List<BorrowerBook>? BorrowerBooks { get; set; } = new();

    }
}
