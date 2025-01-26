using MediatR;
using System.Text.Json.Serialization;

namespace LMS.BorrowersRecord.API.Application.Commands
{
    public record UpsertBorrowerRecordCommand : IRequest<int?>
    {
        [JsonIgnore]
        public int BorrowerId { get; set; }
         public string FullName { get; private set; } = "";
        public string EmailAddress { get; private set; } = "";
        public string PhoneNumber { get; private set; } = "";
        
        public void SetId(int borrowerId)
        {
            BorrowerId = borrowerId;
        }
    }
}