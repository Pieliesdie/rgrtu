using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using TPRLibrary;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Criterions>();

            //var mtrx = new Matrix(new double[,] { { 10, 5, -1 }, { -15, 20, 2 } });

        }
    }
}
