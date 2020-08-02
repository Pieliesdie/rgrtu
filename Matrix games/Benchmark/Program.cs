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

            //var res = mtrx.Grambler();
            //Console.WriteLine(res);
            //var res1 = mtrx.MaxMin();
            //Console.WriteLine(res1);
            //var res2 = mtrx.Gurvic(0.3);
            //Console.WriteLine(res2);
            //var res3 = mtrx.Sevidge();
            //Console.WriteLine(res3);

            //var res4 = mtrx.Baies(new List<double>() { (double)7 / 50, (double)13 / 25, (double)17 / 50 });
            //Console.WriteLine(res4);
            //var res5 = mtrx.Laplas();
            //Console.WriteLine(res5);

            //var res6 = mtrx.HodjesLeman(new List<double>() { (double)7 / 50, (double)13 / 25, (double)17 / 50 }, 0.7);
            //Console.WriteLine(res6);

        }
    }
}
