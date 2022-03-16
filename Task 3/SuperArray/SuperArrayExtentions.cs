using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperArray
{
    public static class SuperArrayExtentions
    {
        public static void ForEach<T>(this T[] array, Action<T> action) => Array.ForEach(array, action);

        public static decimal Sum(this IEnumerable<decimal> source)
        {
            decimal result = 0M;
            foreach (var item in source)
                result += item;

            return result;
        }

        public static double Sum(this IEnumerable<double> source)
        {
            double result = 0.0;
            foreach (var item in source)
                result += item;

            return result;
        }

        public static float Sum(this IEnumerable<float> source)
        {
            float result = 0F;
            foreach (var item in source)
                result += item;

            return result;
        }

        public static int Sum(this IEnumerable<int> source)
        {
            int result = 0;
            foreach (var item in source)
                result += item;

            return result;
        }

        public static long Sum(this IEnumerable<long> source)
        {
            long result = 0L;
            foreach (var item in source)
                result += item;

            return result;
        }
            
        public static decimal Average(this IEnumerable<decimal> source)
            => source.Sum() / source.Count();

        public static double Average(this IEnumerable<double> source)
            => source.Sum() / source.Count();

        public static double Average(this IEnumerable<float> source)
            => (double)source.Sum() / source.Count();

        public static double Average(this IEnumerable<int> source)
            => source.Sum() / (double)source.Count();

        public static double Average(this IEnumerable<long> source)
            => source.Sum() / (double)source.Count();

        public static T FindMostRepeatedElement<T>(this IEnumerable<T> source) where T : notnull
        {
            Dictionary<T, int> itemsRepeats = new();
            foreach (var item in source)
            {
                if (itemsRepeats.ContainsKey(item))
                {
                    itemsRepeats[item]++;
                }
                else
                {
                    itemsRepeats.Add(item, 0);
                }
            }

            return itemsRepeats.MaxBy(pair => pair.Value).Key;
        }
    }
}
