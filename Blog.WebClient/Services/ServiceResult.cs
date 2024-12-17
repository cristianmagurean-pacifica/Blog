namespace Blog.WebClient.Services;

public class ServiceResult<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public HttpResponseMessage Response { get; set; }
}
