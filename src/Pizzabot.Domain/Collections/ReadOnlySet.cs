using System.Collections;

namespace Pizzabot.Domain.Collections
{
    public class ReadOnlySet<T>(ISet<T> source) : IReadOnlySet<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)source).GetEnumerator();
        }

        public int Count => source.Count;

        public bool Contains(T item)
        {
            return source.Contains(item);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return source.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return source.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return source.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return source.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return source.Overlaps(other);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return source.SetEquals(other);
        }
    }
}
