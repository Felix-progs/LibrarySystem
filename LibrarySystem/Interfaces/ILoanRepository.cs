using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?>GetByIdAsync(int id);

        Task <IEnumerable<Loan>> GetActiveLoansAsync();

        Task AddAsync(Loan loan);
        Task UpdateAsync (Loan loan);
      
    }
}
