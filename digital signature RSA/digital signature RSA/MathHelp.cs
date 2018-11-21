using System;

namespace digital_signature_RSA
{
    public static class MathHelp
    {
        private static long GCD(long a, long b, out long x, out long y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            long x1, y1;
            long d = GCD(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }

        public static long ReverseElement(long a, long mod)
        {
            long x, y;
            long g = GCD(a, mod, out x, out y);
            if (g != 1)
                throw new ArgumentException();
            return (x % mod + mod) % mod;
        }

        public static bool IsPrime(long n)
        {
            bool prime = n == 2 || (n != 1 && n % 2 != 0);

            for (long i = 3; prime && i * i <= n; i += 2)
            {
                prime = n % i != 0;
            }

            return prime;
        }

        public static Int64 FastPowFunc(Int64 Number, Int64 Pow, Int64 Mod)
        {
            Int64 Result = 1;
            Int64 Bit = Number % Mod;

            while (Pow > 0)
            {
                if ((Pow & 1) == 1)
                {
                    Result *= Bit;
                    Result %= Mod;
                }
                Bit *= Bit;
                Bit %= Mod;
                Pow >>= 1;
            }
            return Result;
        }
    }
}
