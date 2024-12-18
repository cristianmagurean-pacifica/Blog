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

        blogPost.Update(command.Title, command.Content);

        blogPostRepository.UpdateBlogPost(blogPost);
        await blogPostRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}

