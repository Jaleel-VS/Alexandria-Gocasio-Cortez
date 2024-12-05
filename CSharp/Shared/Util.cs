namespace Utilities;

public class Util
{
    public static class IEnumerableExtensions {
        public static IEnumerable<(T item, int index)> WithIndex<T>(IEnumerable<T> self)       
            => self.Select((item, index) => (item, index));
    }
}
