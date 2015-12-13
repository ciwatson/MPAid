using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Cores
{
    public static class EnumerableExtension
    {
        private static int currentIndex = 0;
        public static T PickNext<T>(this IEnumerable<T> source)
        {
            currentIndex = currentIndex >= source.Count() ? 0 : currentIndex;
            return source.ElementAt(currentIndex++);
        }

        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
