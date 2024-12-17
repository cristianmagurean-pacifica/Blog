using Blog.Domain.Interfaces;
using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record GetBlogPostsQuery : IRequest<IReadOnlyCollection<BlogPost>>;

public class GetBlogPostsQueryHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<GetBlogPostsQuery, IReadOnlyCollection<BlogPost>>
{
    public Task<IReadOnlyCollection<BlogPost>> Handle(GetBlogPostsQuery query, CancellationToken cancellationToken)
    {
        return blogPostRepository.GetAllBlogPostsAsync(cancellationToken);
    }
}