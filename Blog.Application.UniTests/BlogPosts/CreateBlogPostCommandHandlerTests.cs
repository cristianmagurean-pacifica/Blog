using Blog.Application.BlogPosts;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Blog.Application.UnitTests.BlogPosts
{
    public class CreateBlogPostCommandHandlerTests
    {
        private readonly Mock<IBlogPostRepository> _blogPostRepositoryMock;
        private readonly Mock<IUserContext> _userContextMock;
        private readonly CreateBlogPostCommandHandler _handler;

        public CreateBlogPostCommandHandlerTests()
        {
            _blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            _userContextMock = new Mock<IUserContext>();
            _handler = new CreateBlogPostCommandHandler(_blogPostRepositoryMock.Object, _userContextMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateBlogPost()
        {
            // Arrange
            var command = new CreateBlogPostCommand
            {
                BlogPost = new BlogPostDto
                {
                    Title = "Test Title",
                    Content = "Test Content"
                }
            };
            var userId = 1;
            _userContextMock.Setup(x => x.GetCurrentUserId()).Returns(userId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(command.BlogPost.Title, result.Title);
            Assert.Equal(command.BlogPost.Content, result.Content);
            Assert.Equal(userId, result.UserId);
            _blogPostRepositoryMock.Verify(x => x.CreateBlogPost(It.IsAny<BlogPost>()), Times.Once);
            _blogPostRepositoryMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
