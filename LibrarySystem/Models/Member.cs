namespace LibrarySystem.Models
{
    public class Member
    {
        public string MemberId { get; }
        public string Name { get; }
        public string Email { get; }
        public DateTime MemberSince { get;}
        public List<Loan> BorrowedBooks { get; private set; } 

        public Member(string memberId, string name, string email)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            MemberSince = DateTime.Now;
            BorrowedBooks = new List<Loan>();
        }
     
    public string MemberInformation()
        {
            return $"Member ID: {MemberId}, Name: {Name}, Email: {Email}, Member Since: {MemberSince.ToShortDateString()}";
        }
    }
}
