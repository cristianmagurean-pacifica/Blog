using Blog.WebApi.DTO;

namespace Blog.WebClient.Components.Pages;

public partial class Home
{
    private List<BlogPostDto> blogPosts = [];
    private BlogPostDto? selectedBlogPost;
    private bool isAddPostModalVisible = false;  

    protected override async Task OnInitializedAsync()
    {
        blogPosts = await BlogPostsService.GetListAsync();       
    }  

    private void OnAddEditBlogPostModalVisibilityChanged(bool isVisible)
    {
        isAddPostModalVisible = isVisible;
    }

    private async Task AddEditBlogPostAsync(BlogPostDto blogPost)
    {
        if (blogPost.Id == 0)
        {
            var createdBlogPost = await BlogPostsService.InsertAsync(blogPost);
        }
        else
        {
            await BlogPostsService.UpdateAsync(blogPost);
        }
        blogPosts = await BlogPostsService.GetListAsync();
    }

    private void AddBlogPostHandler()
    {
        selectedBlogPost = new BlogPostDto();
        isAddPostModalVisible = true;
    }

    private void EditBlogPostHandler(int postId)
    {
        selectedBlogPost = blogPosts.Single(p => p.Id == postId);
        isAddPostModalVisible = true;
    }

    private async Task DeleteBlogPostHandler(int postId)
    {
        await BlogPostsService.DeleteAsync(postId);
        blogPosts = await BlogPostsService.GetListAsync();
    }
}
