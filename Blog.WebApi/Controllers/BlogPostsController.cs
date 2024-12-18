using AutoMapper;
using Blog.Application.BlogPosts;
using Blog.WebApi.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BlogPostsController : ControllerBase
{
    private readonly ILogger<BlogPostsController> logger;
    private readonly IMapper mapper;
    private readonly IMediator mediator;

    public BlogPostsController(ILogger<BlogPostsController> logger, IMapper mapper, IMediator mediator)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.mediator = mediator;
    }

    // GET: api/BlogPosts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetBlogPosts(CancellationToken cancellationToken)
    {
        logger.LogInformation("Get blog posts");
        var blogPosts = await mediator.Send(new GetBlogPostsQuery(), cancellationToken);
        return Ok(mapper.Map<IEnumerable<BlogPostDto>>(blogPosts));      
    }

    // GET: api/BlogPosts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPostDto>> GetBlogPost(int id, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Get blog post by id: {id}");
        var blogPosts = await mediator.Send(new GetBlogPostByIdQuery(id), cancellationToken);
        return Ok(mapper.Map<BlogPostDto>(blogPosts));
    }

    // POST: api/BlogPosts
    [HttpPost]
    public async Task<ActionResult<BlogPost>> CreateBlogPost(BlogPostDto blogPostDto, CancellationToken cancellationToken)
    {
        logger.LogInformation("Create blog post");
        var createdBlogPost = await mediator.Send(new CreateBlogPostCommand(mapper.Map<BlogPost>(blogPostDto)), cancellationToken);

        return Ok(mapper.Map<BlogPostDto>(createdBlogPost));     
    }

    // PUT: api/BlogPosts
    [HttpPut]
    public async Task<IActionResult> UpdateBlogPost(BlogPost blogPostDto, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Update blog post with id: {blogPostDto.Id}");
        await mediator.Send(new UpdateBlogPostCommand(blogPostDto.Id, blogPostDto.Title, blogPostDto.Content), cancellationToken);

        return NoContent();
    }

    // DELETE: api/BlogPosts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogPost(int id, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Delete blog post with id: {id}");
        await mediator.Send(new DeleteBlogPostCommand(id), cancellationToken);   

        return NoContent();
    }   
}
