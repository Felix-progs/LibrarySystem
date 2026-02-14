using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services
{
    public class MemberRegistry
    {
        private List<Member> members;

        public MemberRegistry()
        {
            members = new List<Member>()
            {
                new Member("M001", "Alice Johnson", "alice@email.com"),
                new Member("M002", "Kalle Andersson", "kalle@email.com"),
                new Member("M003", "Billy Bergström", "billy@email.com"),
                new Member("M004", "Bert Nilsson", "bert@email.com")
            };
        }
        public List<Member> GetAllMembers()
        {
            return members;
        }
        public Member FindMember(string memberId)
        {
            return members.Find(member => member.MemberId == memberId);
        }
    }
}
