﻿using Blog.Domain.Exceptions;
using Blog.Domain.Interfaces;
using MediatR;

namespace Blog.Application.BlogPosts;

public class DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<DeleteBlogPostCommand, bool>
{
    public async Task<bool> Handle(DeleteBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = await blogPostRepository.GetBlogPostByIdAsync(command.Id, cancellationToken) ?? throw new NotFoundException(nameof(BlogPost), command.Id);
        blogPostRepository.DeleteBlogPost(blogPost);
        await blogPostRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}