using MediatR;

namespace Blog.Application.BlogPosts;

public sealed record CreateBlogPostCommand(BlogPost BlogPost) : IRequest<BlogPost>;
