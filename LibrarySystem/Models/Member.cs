namespace LibrarySystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string MemberId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime MemberSince { get; set; }
        
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

        public Member() { }

        public Member(string memberId, string name, string email)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            MemberSince = DateTime.Now;
            
        }
     
    public string MemberInformation()
        {
            return $"Member ID: {MemberId}, Name: {Name}, Email: {Email}, Member Since: {MemberSince.ToShortDateString()}";
        }
    }
}
