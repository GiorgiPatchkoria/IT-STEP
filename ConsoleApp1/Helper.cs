namespace ConsoleApp1
{
    internal class Helper
    {
        #region Where
        public static List<T> Where<T>(List<T> list, Predicate<T> predicate)
        {
            List<T> result = new List<T>();

            foreach (T item in list)
            {
                if (predicate(item))
                    result.Add(item);
            }

            return result;
        }

        #endregion

        #region OrderBy
        public static List<T> OrderBy<T>(List<T> list, Func<T, T, bool> shouldSwap)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (shouldSwap(list[i], list[j]))
                    {
                        T temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

            return list;
        }

        #endregion

        #region First
        public static T First<T>(List<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item))
                    return item;
            }

            throw new Exception("No matching element found");
        }

        #endregion

        #region FirstOrDefault
        public static T FirstOrDefault<T>(List<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item))
                    return item;
            }

            return default;
        }

        #endregion

        #region Single
        public static T Single<T>(List<T> list, Predicate<T> predicate)
        {
            int count = 0;
            T result = default;

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    count++;
                    result = item;
                }
            }

            if (count == 1)
                return result;

            throw new Exception("Matching Element is not one");
        }


        #endregion

        #region SingleOrDefault
        public static T SingleOrDefault<T>(List<T> list, Predicate<T> predicate)
        {
            int count = 0;
            T result = default;

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    count++;
                    result = item;
                }
            }

            if (count == 0)
                return default;

            if (count == 1)
                return result;

            throw new Exception("Matching Element is more than one");
        }

        #endregion

        #region Any
        public static bool Any<T>(List<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item))
                    return true;
            }

            return false;
        }

        #endregion

        #region All
        public static bool All<T>(List<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (!predicate(item))
                    return false;
            }

            return true;
        }

        #endregion

        #region Count
        public static int Count<T>(List<T> list, Predicate<T> predicate)
        {
            int count = 0;

            foreach (T item in list)
            {
                if (predicate(item))
                    count++;
            }

            return count;
        }

        #endregion

        #region Distinct
        public static List<T> Distinct<T>(List<T> list)
        {
            List<T> result = new List<T>();

            foreach (T item in list)
            {
                bool exists = false;

                foreach (T value in result)
                {
                    if (item.Equals(value))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                    result.Add(item);
            }

            return result;
        }

        #endregion
    }
}
