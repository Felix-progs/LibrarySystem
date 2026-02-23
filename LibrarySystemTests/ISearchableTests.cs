using Xunit;
using LibrarySystem.Models;

namespace LibrarySystemTests

{
    public class SearchTests
    {
        [Theory]
        [InlineData("Tolkien", true)]
        [InlineData("tolkien", true)]  // Case-insensitive?
        [InlineData("Rowling", false)]

        public void Book_Matches_ShouldFindByAuthor(string searchTerm, bool expected)
        {

            var book = new Book("Sagan om ringen", "978-91-0-012345-6", "Tolkien", 1954);

            var result = book.Matches(searchTerm);


            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("Rowling", true)]
        [InlineData("rowling", true)]
        [InlineData("Tolkien", false)]
        [InlineData("Harry", true)]
        [InlineData("Sagan om ringen", false)]
        [InlineData("948-91-0-012345-6", true)]
        [InlineData("948-91-0-012345-5", false)]

        public void Book_Matches_BySearchTerm(string searchTerm, bool expected)
        {
            var book = new Book("Harry Potter", "948-91-0-012345-6", "Rowling", 1965);


            var result = book.Matches(searchTerm);


            Assert.Equal(expected, result);
        }
    }
}

