using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibrarySystem.Services
{
    public class LoanManager
    {
        private List<Loan> loans;

        public LoanManager()
        {
            loans = new List<Loan>();
        }

        public Loan BorrowBook(Book book, Member member, int loanDays = 21)
        {
            DateTime loanDate = DateTime.Now;
            DateTime dueDate = loanDate.AddDays(loanDays);

            Loan loan = new Loan(book, member, loanDate, dueDate);
            loans.Add(loan);

            book.IsAvailable = false;
            member.BorrowedBooks.Add(loan);

            return loan;

        }
        public bool ReturnBook(Loan loan)
        {
            if (loans.Contains(loan) && !loan.IsReturned)
            {
                loan.ReturnDate = DateTime.Now;
                loan.Book.IsAvailable = true;
                return true;
            }
            return false;
        }
        public List<Loan> GetAllLoans()
        {
            return loans;
        }

    }
}

