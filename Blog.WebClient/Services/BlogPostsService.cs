using Blog.WebApi.DTO;

namespace Blog.WebClient.Services;

public class BlogPostsService : BaseService<BlogPostDto>, IBlogPostsService
{
    public BlogPostsService(HttpClient client) : base(client)
    {
        ControllerName = "BlogPosts";
    }   
}
