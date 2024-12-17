using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data.Repositories;
public class BlogPostRepository(BlogDbContext blogDbContext) : IBlogPostRepository
{
    public async Task<IReadOnlyCollection<BlogPost>> GetAllBlogPostsAsync(CancellationToken cancellationToken)
    {
       return await blogDbContext.BlogPosts.ToListAsync(cancellationToken);
    }

    public async Task<BlogPost?> GetBlogPostByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await blogDbContext.BlogPosts.FindAsync([id], cancellationToken);
    }

    public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost, CancellationToken cancellationToken)
    {
        blogPost.CreatedAt = DateTime.UtcNow;
        blogPost.UpdatedAt = DateTime.UtcNow;
        blogDbContext.BlogPosts.Add(blogPost);
        await blogDbContext.SaveChangesAsync(cancellationToken);
        return blogPost;
    }

    public async Task<bool> UpdateBlogPostAsync(BlogPost blogPost, CancellationToken cancellationToken)
    {
        var existingBlogPost = await blogDbContext.BlogPosts.FindAsync([blogPost.Id], cancellationToken);
        if (existingBlogPost == null)
        {
            return false;
        }

        existingBlogPost.Title = blogPost.Title;
        existingBlogPost.Content = blogPost.Content;
        existingBlogPost.UpdatedAt = DateTime.UtcNow;

        blogDbContext.Entry(existingBlogPost).State = EntityState.Modified;
        await blogDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteBlogPostAsync(int id, CancellationToken cancellationToken)
    {
        var blogPost = await blogDbContext.BlogPosts.FindAsync([id], cancellationToken);
        if (blogPost == null)
        {
            return false;
        }

        blogDbContext.BlogPosts.Remove(blogPost);
        await blogDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
