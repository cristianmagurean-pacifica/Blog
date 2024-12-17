
namespace Blog.Domain.Interfaces;
public interface IBlogPostRepository
{
    Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost, CancellationToken cancellationToken);
    Task<bool> DeleteBlogPostAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<BlogPost>> GetAllBlogPostsAsync(CancellationToken cancellationToken);
    Task<BlogPost?> GetBlogPostByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> UpdateBlogPostAsync(BlogPost blogPost, CancellationToken cancellationToken);
}
