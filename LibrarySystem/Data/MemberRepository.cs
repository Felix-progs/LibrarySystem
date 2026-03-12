

using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{

    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryContext _context;

        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Member>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Member?> GetByMemberAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Member>> SearchAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Member member)
        {
            throw new NotImplementedException();
        }
    }
}