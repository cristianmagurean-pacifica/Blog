
namespace Blog.Domain.Interfaces;
public interface IBlogPostRepository
{
    void CreateBlogPost(BlogPost blogPost);
    void DeleteBlogPost(BlogPost blogPost);
    Task<IReadOnlyCollection<BlogPost>> GetAllBlogPostsAsync(CancellationToken cancellationToken);
    Task<BlogPost?> GetBlogPostByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    void UpdateBlogPost(BlogPost blogPost);
}
