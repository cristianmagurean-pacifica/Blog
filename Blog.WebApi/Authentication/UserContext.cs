using Blog.Domain.Interfaces;
namespace Blog.WebApi.Authentication;

public class UserContext : IUserContext
{   
    public int GetCurrentUserId()
    {
        return 1; // TO DO: add authentication logic
    }   
}
