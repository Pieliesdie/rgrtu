using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TPRLibrary;
using BenchmarkDotNet.Attributes;
using WPF_Lab2_TPR;

namespace Benchmark
{
    public class Criterions
    {
        private Matrix matrix = new Matrix(new double[,] { { 20, 25, 15, 20, 25, 15 }, { 25, 50, 10, 20, 25, 15 }, { 15, 100, 12, 20, 25, 15 }, { 9, 30, 20, 20, 25, 15 }, { 20, 25, 15, 20, 25, 15 }, { 25, 50, 10, 20, 25, 15 }, { 15, 100, 12, 20, 25, 15 }, { 9, 30, 20, 20, 25, 15 }, { 20, 25, 15, 20, 25, 15 }, { 25, 50, 10, 20, 25, 15 }, { 15, 100, 12, 20, 25, 15 }, { 9, 30, 20, 20, 25, 15 } });

        //private Matrix matrix = new Matrix(new double[,] { {10,5,-1 },{ -15, 20, 2 } });
        //[Benchmark]
        public (int,double) Gurvicv1() => matrix.Gurvic(0.3);

       // [Benchmark]
        public (int, double) Gurvicv2() => _Gurvicv2(matrix, 0.3);

       // [Benchmark]
        public (int, double) Gurvicv3() => _Gurvicv3(matrix, 0.3);

        //[Benchmark]
        public (int, double) Hodjv1() => HodjesLemanv1(matrix, Enumerable.Repeat((double)1/matrix.ColumnCount,matrix.ColumnCount).ToList(),0.3);

       // [Benchmark]
        public (int, double) hodjv2() => HodjesLemanv2(matrix, Enumerable.Repeat((double)1 / matrix.ColumnCount, matrix.ColumnCount).ToList(), 0.3);
        [Benchmark]
        public Matrix riskv1() => GetRisks(matrix);
        [Benchmark]
        public Matrix riskv2() => GetRisksv2(matrix);
       
        Matrix GetRisks(Matrix _matrix)
        {
            return new Matrix
                (Enumerable
                .Range(0, _matrix.RowsCount)
                .Select(i => Enumerable.Range(0, _matrix.ColumnCount)
                    .Select(j => _matrix.Column(j).Max() - _matrix[i, j]))
                .To2DArray());
        }

        Matrix GetRisksv2(Matrix _matrix)
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

        private (int row, double value) _Gurvicv3(Matrix matrix, double pessimism)
        {
            LinkedList<(int, double)> coefs = new LinkedList<(int, double)>();
            for (int i = 0; i < matrix.RowsCount; i++)
            {
                var row = matrix.Row(i);
                coefs.AddLast((i, pessimism * row.Min() + (1 - pessimism) * row.Max()));
            }
            return coefs.OrderByDescending(x => x.Item2).First();
        }

        private (int row, double value) _Gurvicv2(Matrix matrix, double pessimism)
        {
            return Enumerable.Range(0, matrix.RowsCount - 1)
                .Select(x => (x, matrix.Row(x)))
                .Select(x => (x.x, pessimism * x.Item2.Min() + (1 - pessimism) * x.Item2.Max()))
                .OrderByDescending(x => x.Item2)
                .First();
        }

        public static (int row, double value) HodjesLemanv1( Matrix matrix, List<double> chances, double trust)
        {

            LinkedList<(int, double)> meanValues = new LinkedList<(int, double)>();

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                var mean = matrix.Row(i).Zip(chances, (x, y) => x * y).Sum();
                var hodjNumber = trust * mean + (1 - trust) * matrix.Row(i).Min();
                meanValues.AddLast((i, hodjNumber));
            }
            return meanValues.OrderByDescending(x => x.Item2).First();
        }

        public static (int row, double value) HodjesLemanv2( Matrix matrix, List<double> chances, double trust)
        {
            return Enumerable.Range(0, matrix.RowsCount)
                .Select(i => new { row = i, mean = matrix.Row(i).Zip(chances, (x, y) => x * y).Sum() })
                .Select(x => (x.row, trust * x.mean + (1 - trust) * matrix.Row(x.row).Min()))
                .OrderByDescending(x => x.Item2)
                .First();
        }
    }
}
