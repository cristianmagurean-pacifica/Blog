using Blog.Domain.Models;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static BlogPost Create(string title, string content, int userId)
    {
        return new BlogPost
        {
            Title = title,
            Content = content,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }
}
