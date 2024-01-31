namespace shop.domain.Extensions;

public static class GenericExtensions
{
    public static bool IsNull<T>(this T value) => value == null;
    public static bool IsNotNull<T>(this T value) => value != null;
}