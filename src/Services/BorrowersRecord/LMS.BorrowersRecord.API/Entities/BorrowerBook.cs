using LMS.Application.Common.Entities;

namespace LMS.BorrowersRecord.API.Entities
{
   public class BorrowerBook : SqlEntity
    {
        public int BookId {get;set;}
        public BookStatus status {get;set;}

    }
}