using LibrarySystem.Models;
using LibrarySystem.Services;
using Xunit;
using static System.Reflection.Metadata.BlobBuilder;
namespace LibrarySystemTests
{
    public class LibraryStatisticsTests
    {
        [Fact]
        public void GetTotalBooks_ShouldReturnCorrectCount()
        {
            Library library = new Library();

            int totalBooks = library.GetTotalBooks();

            Assert.Equal(5, totalBooks);

        }

        [Fact]
        public void GetBorrowedBooksCount_ShouldReturnCorrectCount()
        {

            Library library = new Library();

            library.BorrowBook("978-0743273565", "M001");
            library.BorrowBook("978-0060935467", "M002");

            int borrowedBooksCount = library.GetBorrowedBooksCount();


            Assert.Equal(2, borrowedBooksCount);
        }

        [Fact]
        public void GetMostActiveBorrower_ShouldReturnMemberWithMostLoans()
        {

            Library library = new Library();

            library.BorrowBook("978-0743273565", "M002");
            library.BorrowBook("978-0060935467", "M002");

            Member mostActiveBorrower = library.GetMostActiveBorrower();
            Assert.NotNull(mostActiveBorrower);
            Assert.Equal("M002", mostActiveBorrower.MemberId);


        }

        [Fact]
        public void SortBooksByTitle_ShouldReturnAlphabeticalOrder()
        {
         Library library = new Library();
            var sortedBooks = library.SortByTitle();
            Assert.Equal("1984", sortedBooks[0].Title);
            Assert.Equal("Pride and Prejudice", sortedBooks[1].Title);
            Assert.Equal("The Catcher in the Rye", sortedBooks[2].Title);
            Assert.Equal("The Great Gatsby", sortedBooks[3].Title);
            Assert.Equal("To Kill a Mockingbird", sortedBooks[4].Title);




        }
    }
}
