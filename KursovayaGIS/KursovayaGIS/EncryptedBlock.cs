using Numerics;
using System;
using System.Collections.Generic;

namespace KursovayaGIS
{
    [Serializable]
    public class EncryptedBlock<T>
    {
        public EncryptedBlock(BigRational message, Dictionary<T, ArithmeticCoder.Range> ranges, int length)
        {
            Message = message;
            Ranges = ranges;
            Length = length;
        }
        public EncryptedBlock()
        {

        }

        public BigRational Message { get; set; }
        public Dictionary<T, ArithmeticCoder.Range> Ranges { get; set; }
        public int Length { get; set; }
    }
}
