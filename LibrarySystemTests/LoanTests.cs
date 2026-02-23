using Xunit;
using LibrarySystem.Models;

namespace LibrarySystemTests
{
    public class LoanTests
    {
        [Fact]
        public void IsOverdue_ShouldReturnFalse_WhenDueDateIsInFuture()
        {

            var book = new Book("123", "Test", "Author", 2024);
            var member = new Member("M006", "Test Person1", "test1@test.com");
            var loan = new Loan(book, member, DateTime.Now, DateTime.Now.AddDays(14));


            Assert.False(loan.IsOverdue);
        }


        [Fact]
        public void IsOverdue_ShouldReturnTrue_WhenDueDateHasPassed()
        {

            var book = new Book("123", "Test", "Author", 2024);
            var member = new Member("M007", "Test Person2", "fdsdf@hotmail.com");
            var loan = new Loan(book, member, DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-15));

            Assert.True(loan.IsOverdue);

        }

        [Fact]
        public void isReturned_ShouldReturnTrue_WhenReturnDateIsSet()
        {

            var book = new Book("123", "Test", "Author", 2024);
            var member = new Member("M008", "Test Person3", "fdsddfdf@hotmail.com");
            var loan = new Loan(book, member, DateTime.Now, DateTime.Now.AddDays(14));

            loan.ReturnDate = DateTime.Now;

            Assert.True(loan.IsReturned);

        }
    }
}



       
