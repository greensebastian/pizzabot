namespace Pizzabot.Domain.Collections
{
    public static class CollectionExtensions
    {
        public static IReadOnlySet<T> AsReadOnly<T>(this ISet<T> set) => new ReadOnlySet<T>(set);
    }
}
