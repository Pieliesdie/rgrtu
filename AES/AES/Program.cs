using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AES
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] key = new byte[] {0x2b,0x7e,0x15,0x16,0x28,0xae,0xd2,0xa6,0xab,0xf7,0x15,0x88,0x09,0xcf,0x4f,0x3c };
            AesCryp A = new AesCryp(key);
            byte[] message = Encoding.Default.GetBytes("qweeeeeeeeeeeeee");
            Console.WriteLine("encrypt");
            var encryptmessage = A.Encrypt(message);
            foreach (byte i in encryptmessage)
            {
                Console.WriteLine(i.ToString("X2"));
            }
            Console.WriteLine("decrypt");
            foreach (byte i in A.Decrypt(encryptmessage))
            {
                Console.WriteLine(i.ToString("X2"));
            }
            //A.SubBytes(state);
        }
    }
}
