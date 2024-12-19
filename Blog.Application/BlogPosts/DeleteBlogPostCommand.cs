using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record DeleteBlogPostCommand(int Id) : IRequest<bool>;
