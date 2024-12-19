using Xunit;

namespace Blog.Domain.Tests.Models
{
    public class BlogPostTests
    {
        [Fact]
        public void Create_ShouldInitializeBlogPostWithCorrectValues()
        {
            // Arrange
            var title = "Test Title";
            var content = "Test Content";
            var userId = 1;

            // Act
            var blogPost = BlogPost.Create(title, content, userId);

            // Assert
            Assert.Equal(title, blogPost.Title);
            Assert.Equal(content, blogPost.Content);
            Assert.Equal(userId, blogPost.UserId);
            Assert.Equal(DateTime.UtcNow.Date, blogPost.CreatedAt.Date);
            Assert.Equal(DateTime.UtcNow.Date, blogPost.UpdatedAt.Date);
        }

        [Fact]
        public void Update_ShouldUpdateBlogPostWithNewValues()
        {
            // Arrange
            var blogPost = new BlogPost
            {
                Title = "Old Title",
                Content = "Old Content",
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1)
            };
            var newTitle = "New Title";
            var newContent = "New Content";

            // Act
            blogPost.Update(newTitle, newContent);

            // Assert
            Assert.Equal(newTitle, blogPost.Title);
            Assert.Equal(newContent, blogPost.Content);
            Assert.Equal(DateTime.UtcNow.Date, blogPost.UpdatedAt.Date);
        }
    }
}
