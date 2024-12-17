using Blog.Domain.Interfaces;
using Blog.Domain.Exceptions;
using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record UpdateBlogPostCommand(int Id, string Title, string Content) : IRequest<bool>;

public class UpdateBlogPostCommandHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<UpdateBlogPostCommand, bool>
{
    public async Task<bool> Handle(UpdateBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = await blogPostRepository.GetBlogPostByIdAsync(command.Id, cancellationToken) ?? throw new NotFoundException(nameof(BlogPost), command.Id);

        blogPost.Title = command.Title;
        blogPost.Content = command.Content;
        blogPost.UpdatedAt = DateTime.UtcNow;

        return await blogPostRepository.UpdateBlogPostAsync(blogPost, cancellationToken);
    }
}

