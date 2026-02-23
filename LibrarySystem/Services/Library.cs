using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public class Library
    {
        private BookCatalog bookCatalog;
        private MemberRegistry memberRegistry;
        private LoanManager loanManager;
        public Library()
        {
            bookCatalog = new BookCatalog();
            memberRegistry = new MemberRegistry();
            loanManager = new LoanManager();
        }
        public List<Book> GetAllBooks()
        {
            return bookCatalog.GetAllBooks();
        }
        public List<Book> SearchBooks(string searchTerm)
        {
            return bookCatalog.SearchBooks(searchTerm);
        }
        public List<Book> SortBooksByYear()
        {
            return bookCatalog.SortByYear();

        }
        public List<Book> SortByTitle()
        {
            return bookCatalog.SortByTitle();
        }
        public List<Book> SortByAuthor()
        {
            return bookCatalog.SortByAuthor();
        }
        public int GetTotalBooks()
        {
            return bookCatalog.GetTotalBooks();
        }
        public int GetBorrowedBooksCount()
        {
            return bookCatalog.GetBorrowedBooksCount();
        }
        public Member GetMostActiveBorrower()
        {
            var members = memberRegistry.GetAllMembers();
            return members.OrderByDescending(member => member.BorrowedBooks.Count).FirstOrDefault();
        }
        public Loan BorrowBook(string isbn, string memberId)
        {
            var book = bookCatalog.GetAllBooks().FirstOrDefault(b => b.ISBN == isbn);
            var member = memberRegistry.FindMember(memberId);


            if (book != null && member != null && book.IsAvailable)
            {
                return loanManager.BorrowBook(book, member);
            }
            return null;
        }
        public bool ReturnBook(Loan loan)
        {
            return loanManager.ReturnBook(loan);
        }
        public List<Loan> GetAllLoans()
        {
            return loanManager.GetAllLoans();
        }
    }

}
