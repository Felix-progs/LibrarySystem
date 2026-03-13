using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;


namespace LibrarySystem.Data
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;

        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Loan>> GetActiveLoansAsync()
        {
            return await _context.Loans
                .Include(L => L.Book)
                .Include(L => L.Member)
                .Where(L => L.ReturnDate == null)
                .ToListAsync();

        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _context.Loans
                 .Include(L => L.Book)
                 .Include(L => L.Member)
                 .ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans
                .Include(L => L.Book)
                .Include(L => L.Member)
                .FirstOrDefaultAsync(L => L.Id == id);
        }

        public async Task UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
