using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record UpdateBlogPostCommand(int Id, string Title, string Content) : IRequest<bool>;

