using Blog.WebApi.DTO;
using Microsoft.AspNetCore.Components;

namespace Blog.WebClient.Components.Pages;

public partial class AddEditBlogPostModal
{
    [Parameter] public bool IsVisible { get; set; }
    [Parameter] public EventCallback<bool> IsVisibleChanged { get; set; }
    [Parameter] public required BlogPostDto SelectedBlogPost { get; set; }
    [Parameter] public EventCallback<BlogPostDto> SelectedBlogPostChanged { get; set; }
    [Parameter] public EventCallback<BlogPostDto> OnPostAddEdit { get; set; }

    private async Task HandleValidSubmit()
    {
        await OnPostAddEdit.InvokeAsync(SelectedBlogPost);       
        await CloseModal();
    }

    private async Task CloseModal()
    {
        IsVisible = false;
        await IsVisibleChanged.InvokeAsync(IsVisible);
    }
}
