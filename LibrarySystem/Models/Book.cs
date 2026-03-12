using System;
using System.Collections.Generic;
using System.Text;
using LibrarySystem.Interfaces;

namespace LibrarySystem.Models
{
    public class Book: ISearchable
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; }  = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public Book() { }
        public Book (string title, string isbn, string author, int publishedYear)
        {
            Title = title;
            ISBN = isbn;
            Author = author;
            PublishedYear = publishedYear;
            IsAvailable = true;

        }
        public string GetInfo()
        {
            return $"{Title} by {Author}, published in {PublishedYear}. ISBN: {ISBN}. Available: {IsAvailable}";
        }
        public bool Matches(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return false;
                
            return Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                   Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                   ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
        }
    }
}
