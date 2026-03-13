
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces;

namespace LibrarySystem.Data
{
    public class BookRepository : IBookRepository

    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }





        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                 await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book?> GetByISBNAsync(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync
                (b => b.ISBN == isbn);
        }

        public async Task<IEnumerable<Book>> SearchAsync(string searchTerm)
        {
            return await _context.Books
                .Where(b => b.Matches(searchTerm))
                .ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var existing = await _context.Books.FindAsync(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.ISBN = book.ISBN;
                existing.PublishedYear = book.PublishedYear;
                existing.IsAvailable = book.IsAvailable;
                await _context.SaveChangesAsync();
            }
        }
    }
}