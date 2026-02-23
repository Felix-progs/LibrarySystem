using Xunit;
using LibrarySystem.Models;
namespace LibrarySystemTests

{
    public class BookTests
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange & Act
            var book = new Book("Testbook","978-91-0-012345-6", "Author", 2024);

            // Assert
            Assert.Equal("978-91-0-012345-6", book.ISBN);
            Assert.Equal("Testbook", book.Title);
            Assert.True(book.IsAvailable);
        }

        [Fact]
        public void IsAvailable_ShouldBeTrueForNewBook()
        {
            var book = new Book("Testbook1", "978-92-0-012345-5", "Felix", 2021);


            Assert.True(book.IsAvailable);
        }

        [Fact]
        public void GetInfo_ShouldReturnFormattedString()
        {

            var book = new Book("Testbook2", "978-93-0-012345-4", "Felix1", 2022);

            string expectedInfo = book.GetInfo();

            Assert.Contains("Testbook2", expectedInfo);
            Assert.Contains("978-93-0-012345-4", expectedInfo);
            Assert.Contains("Felix1", expectedInfo);
            Assert.Contains("2022", expectedInfo);
        }
    }
}

