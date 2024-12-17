using Blog.WebApi.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blog.WebClient.Components.Pages;

public partial class Home
{
    private List<BlogPostDto> blogPosts = [];

    protected override async Task OnInitializedAsync()
    {
        blogPosts = await BlogPostsService.GetListAsync();
    }

    private void NavigateToAddBlogPost()
    {
        Navigation.NavigateTo("/add-post");
    }
}
