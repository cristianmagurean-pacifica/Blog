using Blog.Domain.Interfaces;
using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record CreateBlogPostCommand(BlogPost BlogPost) : IRequest<BlogPost>;

public class CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<CreateBlogPostCommand, BlogPost>
{
    public async Task<BlogPost> Handle(CreateBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = new BlogPost
        {
            Title = command.BlogPost.Title,
            Content = command.BlogPost.Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return await blogPostRepository.CreateBlogPostAsync(blogPost, cancellationToken);
    }
}
