using Numerics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace KursovayaGIS
{
    public static class Parser
    {
        public static byte[] Encode(EncryptedBlock<byte>[] encryptedBlocks)
        {
            if (encryptedBlocks == null || encryptedBlocks.Length == 0)
            {
                return new byte[0];
            }
            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);

            bw.Write(BitConverter.GetBytes(encryptedBlocks.Length));
            bw.Write(BitConverter.GetBytes(encryptedBlocks.First().Length));
            foreach (var block in encryptedBlocks)
            {
                bw.Write(BitConverter.GetBytes(block.Ranges.Count * 2));
                foreach (var range in block.Ranges)
                {
                    bw.Write(range.Key);
                    BigInteger minrange_numerator = range.Value.minRange.Numerator;
                    BigInteger minrange_Denominator = range.Value.minRange.Denominator;

                    BigInteger maxrange_numerator = range.Value.maxRange.Numerator;
                    BigInteger maxrange_Denominator = range.Value.maxRange.Denominator;
                    bw.Write(minrange_numerator.GetByteCount());
                    bw.Write(minrange_numerator.ToByteArray());
                    bw.Write(minrange_Denominator.GetByteCount());
                    bw.Write(minrange_Denominator.ToByteArray());

                    bw.Write(maxrange_numerator.GetByteCount());
                    bw.Write(maxrange_numerator.ToByteArray());
                    bw.Write(maxrange_Denominator.GetByteCount());
                    bw.Write(maxrange_Denominator.ToByteArray());
                }

                var message_Numerator = block.Message.Numerator;
                var message_Denominator = block.Message.Denominator;
                bw.Write(message_Numerator.GetByteCount());
                bw.Write(message_Numerator.ToByteArray());

                bw.Write(message_Denominator.GetByteCount());
                bw.Write(message_Denominator.ToByteArray());
            }
            return ms.ToArray();
        }

        public static EncryptedBlock<byte>[] Decode(byte[] encryptedBlocks)
        {
            var result = new List<EncryptedBlock<byte>>();
            using var ms = new MemoryStream(encryptedBlocks);
            using var br = new BinaryReader(ms);
            var countOfBlocks = br.ReadInt32();
            var sizeOfblock = br.ReadInt32();
            for (int i = 0; i < countOfBlocks; i++)
            {
                var ranges = new Dictionary<byte, ArithmeticCoder.Range>();
                var countOfRanges = br.ReadInt32();
                for (int j = 0; j < countOfRanges / 2; j++)
                {
                    var key = br.ReadByte();
                    BigInteger minrange_numerator = new BigInteger(br.ReadBytes(br.ReadInt32()));
                    BigInteger minrange_Denominator = new BigInteger(br.ReadBytes(br.ReadInt32())); 

                    BigInteger maxrange_numerator = new BigInteger(br.ReadBytes(br.ReadInt32())); 
                    BigInteger maxrange_Denominator = new BigInteger(br.ReadBytes(br.ReadInt32()));
                    var minrange = new BigRational(minrange_numerator, minrange_Denominator);
                    var maxrange = new BigRational(maxrange_numerator, maxrange_Denominator);

                    var range = new ArithmeticCoder.Range(minrange, maxrange);
                    ranges.Add(key, range);
                }
                var message_Numerator = new BigInteger(br.ReadBytes(br.ReadInt32()));
                var message_Denominator = new BigInteger(br.ReadBytes(br.ReadInt32()));

                var message = new BigRational(message_Numerator, message_Denominator);

            result.Add(new EncryptedBlock<byte>(message, ranges, sizeOfblock));
            }
            return result.ToArray();
        }
    }
}
