using Blog.Domain.Extensions;
using Xunit;

namespace Blog.Domain.Tests.Extensions
{
    public class DataTimeExtensionsTests
    {
        [Fact]
        public void FormatDate_ShouldReturnFormattedDate()
        {
            // Arrange
            var dateTime = new DateTime(2023, 10, 15);

            // Act
            var formattedDate = dateTime.FormatDate();

            // Assert
            Assert.Equal("October 15, 2023", formattedDate);
        }    
    }
}
