using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task<Member?> GetByMemberAsync(string memberId);

        Task AddAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(int id);

        Task<IEnumerable<Member>> SearchAsync(string searchTerm);
    }
}
