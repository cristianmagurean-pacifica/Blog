using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data.Repositories;
public class BlogPostRepository(BlogDbContext blogDbContext) : IBlogPostRepository
{
    public async Task<IReadOnlyCollection<BlogPost>> GetAllBlogPostsAsync(CancellationToken cancellationToken)
    {
       return await blogDbContext.BlogPosts
            .Include(blogPost => blogPost.User)     
            .ToListAsync(cancellationToken);
    }

    public async Task<BlogPost?> GetBlogPostByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await blogDbContext.BlogPosts.FindAsync([id], cancellationToken);
    }

    public void CreateBlogPost(BlogPost blogPost)
    {       
        blogDbContext.BlogPosts.Add(blogPost);       
    }

    public void UpdateBlogPost(BlogPost blogPost)
    {
        blogDbContext.BlogPosts.Update(blogPost);
    }

    public void DeleteBlogPost(BlogPost blogPost)
    {
        blogDbContext.BlogPosts.Remove(blogPost);     
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {      
        return await blogDbContext.SaveChangesAsync(cancellationToken);      
    }
}
