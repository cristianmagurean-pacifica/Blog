namespace Blog.Domain.Extensions;
public static class StringExtensions
{
    public static string ShowFirst(this string info, int size)
    {
        if (info.Length > size)
        {
            return string.Concat(info.AsSpan(0, size), "...");
        }

        return info;
    }
}
