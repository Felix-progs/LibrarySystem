namespace LibrarySystem.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId {  get; set; }
        public Book? Book { get; set; }
        public Member? Member { get; set; } 
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Loan() { }

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
