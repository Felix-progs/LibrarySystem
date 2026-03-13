

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

        public async Task DeleteAsync(int id)
        {
            var member = await GetByIdAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<Member?> GetByMemberAsync(string memberId)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.MemberId == memberId);
        }

        public async Task<IEnumerable<Member>> SearchAsync(string searchTerm)
        {
            return await _context.Members
                .Where(m => m.Name.Contains(searchTerm,StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task UpdateAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }
    }
}