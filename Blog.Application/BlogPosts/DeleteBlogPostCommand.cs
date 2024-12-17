using Blog.Domain.Exceptions;
using Blog.Domain.Interfaces;
using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record DeleteBlogPostCommand(int Id) : IRequest<bool>;

public class DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<DeleteBlogPostCommand, bool>
{
    public async Task<bool> Handle(DeleteBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = await blogPostRepository.GetBlogPostByIdAsync(command.Id, cancellationToken) ?? throw new NotFoundException(nameof(BlogPost), command.Id);
        return await blogPostRepository.DeleteBlogPostAsync(command.Id, cancellationToken);
    }
}