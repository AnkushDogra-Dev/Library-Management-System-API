using LMS.Application.Common.Entities;

namespace LMS.BorrowersRecord.API.Entities
{
    public class Borrower : SqlEntity
    {
        public string FullName { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<BorrowerBook>? BorrowerBooks { get; set; } = new();

        public Borrower(string fullName, string emailAddress, string phoneNumber)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public void AddBorrowerBook(BorrowerBook borrowerBooks)
        {
            BorrowerBooks?.Add(borrowerBooks);
        }

        public void UpdateBorrowerDetails(string fullName, string emailAddress, string phoneNumber)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
