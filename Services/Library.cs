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
        public List<Book>SortByTitle()
        {
            return bookCatalog.SortByTitle();
        }
        public List<Book> SortByAuthor()
        {
            return bookCatalog.SortByAuthor();
        }
        public int getTotalBooks()
        {
            return bookCatalog.GetTotalBooks();
        }
        public int GetBorrowedBooksCount()
        {
            return bookCatalog.GetBorrowedBooksCount();
        }
        public Member getMostActiveMember()
        {
            var members = memberRegistry.GetAllMembers();
            return members.OrderByDescending(m => m.BorrowedBooks.Count).FirstOrDefault();
        }






    }
}
