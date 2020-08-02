using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Numerics;

namespace KursovayaGIS
{
    public static class ArithmeticCoder
    {
        [Serializable]
        public struct Range
        {
            public BigRational minRange { get; }
            public BigRational maxRange { get; }

            public Range(BigRational minRange, BigRational maxRange)
            {
                this.minRange = minRange;
                this.maxRange = maxRange;
            }
        }

        public static T[] Decode<T>(BigRational Message, Dictionary<T, Range> ranges, int length)
        {
            var result = new List<T>();
            var number = Message;
            //var k = 1;
            for (int i = 0; i < length; i++)
            {
                //Console.WriteLine($"Decoding {k++} / {length}");
                var symbol = ranges.Where(x => x.Value.minRange <= number && number < x.Value.maxRange).FirstOrDefault();
                var range = symbol.Value.maxRange - symbol.Value.minRange;
                number -= symbol.Value.minRange;
                number /= range;
                result.Add(symbol.Key);
            }
            return result.ToArray();
        }

        public static (BigRational Message, Dictionary<T, Range> Ranges, int Length) Encode<T>(T[] source)
        {
            //get ranges
            
            var lastMin =new BigRational(0,1);
            var ranges = source.OrderBy(x=>x).GroupBy(x => x).ToDictionary(x => x.Key,
                x =>
                {
                    var minRange = lastMin;
                    var maxRange = lastMin+ new BigRational(x.Count(),source.Length);
                    lastMin = maxRange;
                    return new Range(minRange, maxRange);
                });

            //foreach (var i in ranges)
            //    Console.WriteLine(i.Key + " " + i.Value.minRange.ToDecimalString(5) + "-" + i.Value.maxRange.ToDecimalString(5));

            //encode
            var low = new BigRational(0,1);
            var high = new BigRational(1,1);
           // var k = 1;
            foreach (var i in source)
            {
               // Console.WriteLine($"Encoding {k++} / {source.Length}");
                var range = high - low;
                var ItemRange = ranges[i];
                high = low + range * ItemRange.maxRange;
                low = low + range * ItemRange.minRange;
                //Console.WriteLine($"encoding {i}\nlow = {low.ToDecimalString(100)}\nhigh = {high.ToDecimalString(100)}\n");

            }

            return (low, ranges, source.Length);

        }
    }
}
