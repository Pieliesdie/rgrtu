using System;
using System.Collections.Generic;
using System.Linq;
using WPF_Lab2_TPR;

namespace TPRLibrary
{
    public static class Criterions
    {
        public static bool DoubleEqual(this double source, double other) => Math.Abs(source - other) <= 0.0001;

        public static int Grambler(this Matrix matrix) => matrix.Gurvic(0);

        public static int MaxMin(this Matrix matrix) => matrix.Gurvic(1);

        public static int Gurvic(this Matrix matrix, double pessimism)
        {
            if (matrix == null || matrix.RowsCount == 0 || matrix.ColumnCount == 0)
                throw new Exception("Invalid matrix");

            if (pessimism < 0 || pessimism > 1)
                throw new Exception("pessimism must be between 0 and 1");

            List<double> GurvicNumbers = new List<double>();

            for(int i = 0; i < matrix.RowsCount; i++)
            {
                var GurvicNumber = pessimism * matrix.Row(i).Min() + (1 - pessimism) * matrix.Row(i).Max();
                GurvicNumbers.Add(GurvicNumber);
            }

            return GurvicNumbers.IndexOf(GurvicNumbers.Max());
            
        }

        public static int Sevidge(this Matrix matrix)
        {
            Matrix GetRisks(Matrix _matrix)
            {            
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

            if (matrix == null || matrix.RowsCount == 0 || matrix.ColumnCount == 0)
                throw new Exception("Invalid matrix");

            var risk = GetRisks(matrix);

            var riskMaxes = new List<double>();

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                riskMaxes.Add(risk.Row(i).Max());
            }

            return riskMaxes.IndexOf(riskMaxes.Min());
        }

        public static int Baies(this Matrix matrix, List<double> chances) => HodjesLeman(matrix, chances, 1);

        public static int Laplas(this Matrix matrix) => Baies(matrix, Enumerable.Repeat((double)1 / matrix.ColumnCount, matrix.ColumnCount).ToList());

        public static int HodjesLeman(this Matrix matrix, List<double> chances, double trust)
        {
            if (matrix == null || matrix.RowsCount == 0 || matrix.ColumnCount == 0)
                throw new Exception("Invalid matrix");

            if (!chances.Sum().DoubleEqual(1))
            {
                throw new Exception("Chances's sum must be equal 1");
            }
            if (chances.Count() != matrix.ColumnCount)
            {
                throw new Exception("Matrix length not equal chances");
            }
            List<double> HodjesNumbers = new List<double>();

            for(int i = 0; i < matrix.RowsCount; i++)
            {
                var row = matrix.Row(i);

                var mean = row.Select(x => x * chances[i]).Sum();

                var hodjesNumber = trust * mean + (1 - trust) * row.Min();

                HodjesNumbers.Add(mean);
            }

            return HodjesNumbers.IndexOf(HodjesNumbers.Max());
        }
    }
}
