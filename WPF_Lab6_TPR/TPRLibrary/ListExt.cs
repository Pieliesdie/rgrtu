using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Lab2_TPR
{
    public static class ListExt
    {
        public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> src)
        {
            var countOfRows = src.Count();
            var countOfColumns = src.First().Count();
            var result = new T[countOfRows, countOfColumns];

            for(int i = 0; i < countOfRows; i++)
            {
                for(int j = 0; j < countOfColumns; j++)
                {
                    result[i, j] = src.ElementAt(i).ElementAt(j);
                }
            }

            return result;
        }


    }
}
