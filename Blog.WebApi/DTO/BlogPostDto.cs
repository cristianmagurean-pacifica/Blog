using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Blog.WebApi.DTO;

public class BlogPostDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The Title must be at most 100 characters long.")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(1000, ErrorMessage = "The Content must be at most 1000 characters long.")]
    public string Content { get; set; } = string.Empty;
    public UserDto User { get; set; } = new UserDto();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class BlogPostProfile : Profile
{
    public BlogPostProfile()
    {
        CreateMap<BlogPost, BlogPostDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
            .ReverseMap()
            .ForMember(dest => dest.User, opt => opt.Ignore());
    }
}
