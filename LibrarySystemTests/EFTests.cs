using LibrarySystem.Data;
using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Moq;
using Xunit;

namespace LibrarySystemTests
{
    public class EFTests
    {
        
        [Fact]
        public async Task BookRepository_GetAllAsync_ShouldReturnAllBooks()
        {
            var mock = new Mock<IBookRepository>();
            mock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Book>
            {
                new Book("Book1", "1234567890123", "Author1", 2020),
                new Book("Book2", "1234567890124", "Author2", 2021)
            });

            var result = await mock.Object.GetAllAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task MemberRepository_GetAllAsync_ShouldReturnAllMembers()
        {
            var mock = new Mock<IMemberRepository>();
            mock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Member>
            {
                new Member("M001", "Test User", "test@test.com")
            });

            var result = await mock.Object.GetAllAsync();
            Assert.Single(result);
        }

        [Fact]
        public async Task BookRepository_GetByIdAsync_ShouldReturnCorrectBook()
        {
            var mock = new Mock<IBookRepository>();
            var book = new Book("Test", "1234567890123", "Author", 2020);
            mock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(book);

            var result = await mock.Object.GetByIdAsync(1);
            Assert.Equal("Test", result?.Title);
        }

        [Fact]
        public async Task LoanRepository_GetAllAsync_ShouldReturnAllLoans()
        {
            var mock = new Mock<ILoanRepository>();
            var book = new Book("Test", "1234567890123", "Author", 2020);
            var member = new Member("M001", "Test User", "test@test.com");
            var loan = new Loan(book, member, DateTime.Now, DateTime.Now.AddDays(14));
            mock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Loan> { loan });

            var result = await mock.Object.GetAllAsync();
            Assert.Single(result);
        }

       
        [Fact]
        public async Task BookRepository_AddAsync_ShouldBeCalled()
        {
            var mock = new Mock<IBookRepository>();
            var book = new Book("New Book", "1234567890123", "Author", 2020);

            await mock.Object.AddAsync(book);

            mock.Verify(r => r.AddAsync(book), Times.Once);
        }

        [Fact]
        public async Task BookRepository_DeleteAsync_ShouldBeCalled()
        {
            var mock = new Mock<IBookRepository>();

            await mock.Object.DeleteAsync(1);

            mock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task BookRepository_UpdateAsync_ShouldBeCalled()
        {
            var mock = new Mock<IBookRepository>();
            var book = new Book("Updated", "1234567890123", "Author", 2020);

            await mock.Object.UpdateAsync(book);

            mock.Verify(r => r.UpdateAsync(book), Times.Once);
        }

       
        [Fact]
        public async Task LoanRepository_GetActiveLoans_ShouldReturnOnlyActiveLoans()
        {
            var mock = new Mock<ILoanRepository>();
            var book = new Book("Test", "1234567890123", "Author", 2020);
            var member = new Member("M001", "Test User", "test@test.com");
            var loan = new Loan(book, member, DateTime.Now, DateTime.Now.AddDays(14));
            mock.Setup(r => r.GetActiveLoansAsync()).ReturnsAsync(new List<Loan> { loan });

            var result = await mock.Object.GetActiveLoansAsync();
            Assert.Single(result);
        }

        [Fact]
        public async Task BookRepository_SearchAsync_ShouldReturnMatchingBooks()
        {
            var mock = new Mock<IBookRepository>();
            mock.Setup(r => r.SearchAsync("Harry")).ReturnsAsync(new List<Book>
            {
                new Book("Harry Potter", "1234567890123", "Rowling", 2000)
            });

            var result = await mock.Object.SearchAsync("Harry");
            Assert.Single(result);
        }

        [Fact]
        public async Task MemberRepository_GetByMemberAsync_ShouldReturnCorrectMember()
        {
            var mock = new Mock<IMemberRepository>();
            var member = new Member("M001", "Test User", "test@test.com");
            mock.Setup(r => r.GetByMemberAsync("M001")).ReturnsAsync(member);

            var result = await mock.Object.GetByMemberAsync("M001");
            Assert.Equal("M001", result?.MemberId);
        }
    }
}