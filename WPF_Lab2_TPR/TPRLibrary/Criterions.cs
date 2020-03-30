using System;
using System.Collections.Generic;
using System.Linq;
using WPF_Lab2_TPR;

namespace TPRLibrary
{
    public static class Criterions
    {
        public static bool DoubleEqual(this double source, double other)
        {
            const double eps = 0.0000001;
            return Math.Abs(source - other) <= eps;
        }

        private static void _checkInput(Matrix matrix)
        {
            if (matrix == null || matrix.RowsCount == 0 || matrix.ColumnCount == 0)
                throw new Exception("Invalid matrix");
        }

        public static (int row, double value) Grambler(this Matrix matrix) => matrix.Gurvic(0);

        public static (int row, double value) MaxMin(this Matrix matrix) => matrix.Gurvic(1);

        public static (int row, double value) Gurvic(this Matrix matrix, double pessimism)
        {
            _checkInput(matrix);
            if (pessimism < 0 || pessimism > 1)
                throw new Exception("pessimism must be between 0 and 1");

            return Enumerable.Range(0, matrix.RowsCount)
                .Select(x => (x, pessimism * matrix.Row(x).Min() + (1 - pessimism) * matrix.Row(x).Max()))
                .OrderByDescending(x => x.Item2)
                .First();
        }

        public static (int row, double value) Sevidge(this Matrix matrix)
        {
            Matrix GetRisks(Matrix _matrix)
            {
                //return new Matrix
                //    (Enumerable
                //    .Range(0, _matrix.RowsCount)
                //    .Select(i => Enumerable.Range(0, _matrix.ColumnCount)
                //        .Select(j =>_matrix.Column(j).Max() - _matrix[i,j]))
                //    .To2DArray());
             
                var risks = new Matrix(_matrix.RowsCount, _matrix.ColumnCount);
  
                for (int i = 0; i < _matrix.ColumnCount; i++)
                {
                    var maxInColumn = _matrix.Column(i).Max();

                    for (int j = 0; j < _matrix.RowsCount; j++)
                    {
                        risks[j, i] = maxInColumn - _matrix[j, i];
                    }
                }
                return risks;
            }

            _checkInput(matrix);

            var risk = GetRisks(matrix);

            return Enumerable.Range(0, matrix.RowsCount)
                .Select(i => (i, risk.Row(i).Max()))
                .OrderBy(x => x.Item2)
                .First();
        }

        public static (int row, double value) Baies(this Matrix matrix, IEnumerable<double> chances) => HodjesLeman(matrix, chances, 1);

        public static (int row, double value) Laplas(this Matrix matrix) => Baies(matrix, Enumerable.Repeat((double)1 / matrix.ColumnCount, matrix.ColumnCount).ToList());

        public static (int row, double value) HodjesLeman(this Matrix matrix, IEnumerable<double> chances, double trust)
        {
            _checkInput(matrix);
            if (!chances.Sum().DoubleEqual(1))
            {
                throw new Exception("chances's sum must be equal 1");
            }
            if (chances.Count() != matrix.ColumnCount)
            {
                throw new Exception("matrix length not equal chances");
            }

            return Enumerable.Range(0, matrix.RowsCount)
                .Select(i => new { row = i, mean = matrix.Row(i).Zip(chances, (x, y) => x * y).Sum() })
                .Select(x => (x.row, trust * x.mean + (1 - trust) * matrix.Row(x.row).Min()))
                .OrderByDescending(x=>x.Item2)
                .First();
        }
    }
}
