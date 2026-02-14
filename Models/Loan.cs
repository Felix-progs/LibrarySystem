namespace LibrarySystem.Models
{
    public class Loan
    {
        public Book Book { get;}
        public Member Member { get;}
        public DateTime LoanDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate { get; set; }

        public Loan(Book book, Member member, DateTime loanDate, DateTime dueDate)
        {
            Book = book;
            Member = member;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = null;
        }
        public bool IsOverdue
        {
            get
            {
                return ReturnDate == null && DateTime.Now > DueDate;
            }
        }

        public bool IsReturned
        {
            get
            {
                return ReturnDate != null;
            }

        }
    }
}
