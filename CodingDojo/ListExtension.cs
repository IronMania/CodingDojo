using System.Collections.Generic;

namespace CodingDojo
{
    public static class ListExtension {
        public static List<T> Replace<T> (this List<T> list, T oldValue, T newValue)

        {
            var index = list.IndexOf(oldValue);
            if (index != -1)
                list[index] = newValue;
            return list;
        }
    }
}