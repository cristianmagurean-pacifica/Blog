using Blog.WebClient.Components;
using Blog.WebClient.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Blog.WebAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7030/");
    client.Timeout = TimeSpan.FromMinutes(30);
});   

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("Blog.WebAPI"));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IBlogPostsService, BlogPostsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
