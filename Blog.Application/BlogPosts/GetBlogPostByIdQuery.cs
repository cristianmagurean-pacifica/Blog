using Blog.Domain.Interfaces;
using Blog.Domain.Exceptions;
using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record GetBlogPostByIdQuery(int Id) : IRequest<BlogPost>;

public class GetBlogPostByIdQueryHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<GetBlogPostByIdQuery, BlogPost>
{
    public Task<BlogPost> Handle(GetBlogPostByIdQuery query, CancellationToken cancellationToken)
    {
        var blogPost = blogPostRepository.GetBlogPostByIdAsync(query.Id, cancellationToken) ?? throw new NotFoundException(nameof(BlogPost), query.Id);
        return blogPost!;
    }
}