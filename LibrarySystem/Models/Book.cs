using System;
using System.Collections.Generic;
using System.Text;
using LibrarySystem.Interfaces;

namespace LibrarySystem.Models
{
    public class Book: ISearchable
    {
        public string Title { get;}
        public string ISBN { get;}
        public string Author { get;}
        public int PublishedYear { get;}
        public bool IsAvailable { get; set; }

        public Book (string title, string isbn, string author, int publishedYear)
        {
            ISBN = isbn;
            Title = title;
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
