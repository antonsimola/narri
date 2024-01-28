using System.Collections.Generic;

namespace DefaultNamespace.Utility
{
    public static class EnumerableExtensions
    {
        public  static T GetRandomFromList<T>(this IList<T> list)
        {
            if (list.Count == 0) return default;
            
            var i = GameController.instance.Random.Next(0, list.Count);
            return list[i];
        }
    }
}