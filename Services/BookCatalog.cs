using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibrarySystem.Services
{

    public class BookCatalog
    {
        private List<Book> books;

        public BookCatalog()

        {
            books = new List<Book>
            {
            new Book("The Great Gatsby", "978-0743273565", "F. Scott Fitzgerald", 1925),
            new Book("To Kill a Mockingbird", "978-0060935467", "Harper Lee", 1960),
            new Book("1984", "978-0451524935", "George Orwell", 1949),
            new Book("Pride and Prejudice", "978-1503290563", "Jane Austen", 1813),
            new Book("The Catcher in the Rye", "978-0316769488", "J.D. Salinger", 1951)
            };

        }

        public List <Book> SearchBooks(string searchTerm)
        {
            return books.Where(book => book.Matches(searchTerm)).ToList();    
        }
        public List <Book> SortByTitle()
        {
            return books.OrderBy(book => book.Title).ToList();
        }
        public List <Book> SortByAuthor()
        {
            return books.OrderBy(Book => Book.Author).ToList();
        }
        public List <Book> SortByYear()
        {
            return books.OrderBy(book => book.PublishedYear).ToList();
        }
        public List<Book> GetAllBooks()
        {
            return books;
        }
        public int GetTotalBooks()
        {
            return books.Count;
        }
        public int GetBorrowedBooksCount()
        {
            return books.Count(book => book.IsAvailable);
        }

    }
}
    
    










