namespace Blog.Domain.Extensions;
public static class DataTimeExtensions
{
    public static string FormatDate(this DateTime dateTime)
    {
        return dateTime.ToString("MMMM dd, yyyy");
    }
}
