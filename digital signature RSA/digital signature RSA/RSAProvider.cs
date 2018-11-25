namespace digital_signature_RSA
{
    class RSAProvider
    {
        public long PrivateKey { get; }
        public long PublicKeyE { get; }
        public long PublicKeyN { get; }

        private static long GetE(long m)
        {
            if (m > 65537)
            {
                return 65537;
            }
            if (m > 257)
            {
                return 257;
            }
            if (m > 17)
            {
                return 17;
            }
            if (m > 5)
            {
                return 5;
            }
            return 3;
        }

        public RSAProvider(int p,int q)
        {
            checked
            {
                PublicKeyN = p * q;
            }
            long m = (p - 1) * (q - 1);
            PublicKeyE = GetE(m);
            PrivateKey = MathHelp.ReverseElement(PublicKeyE, m);
        }

        public static long Encrypt(long s, long e, long n)
        {
            return MathHelp.FastPowFunc(s, e, n);
        }

        public static long Decrypt(long s, long d, long n)
        {
            return Encrypt(s, d, n);
        }
    }
}
