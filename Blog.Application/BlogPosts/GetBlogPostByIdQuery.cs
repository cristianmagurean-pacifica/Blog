using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record GetBlogPostByIdQuery(int Id) : IRequest<BlogPost>;
