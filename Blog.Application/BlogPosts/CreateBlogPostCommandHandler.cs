using Blog.Domain.Interfaces;
using MediatR;

namespace Blog.Application.BlogPosts;

public class CreateBlogPostCommandHandler(
    IBlogPostRepository blogPostRepository,
    IUserContext userContext) : IRequestHandler<CreateBlogPostCommand, BlogPost>
{
    public async Task<BlogPost> Handle(CreateBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = BlogPost.Create(command.BlogPost.Title, command.BlogPost.Content, userContext.GetCurrentUserId());
        blogPostRepository.CreateBlogPost(blogPost);
        await blogPostRepository.SaveChangesAsync(cancellationToken);

        return blogPost;
    }
}
