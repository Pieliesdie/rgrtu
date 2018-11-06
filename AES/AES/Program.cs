using System;
using System.Collections.Generic;
using System.Text;

namespace AES
{
    class Program
    {
        public static List<byte[]> StringToAesBlocks(string s)
        {
            List<byte[]> tmp = new List<byte[]>();
            while(s.Length%16!= 0)
            {
                s += " ";
            }
            for(int i =0; i < s.Length; i += 16)
            {
                string block="";
                for(int j = i; j < i + 16; j++)
                {
                    block += s[j];
                }
                tmp.Add(Encoding.Default.GetBytes(block));
            }
            return tmp;
        }

        static void Main(string[] args)
        {
            byte[] key = new byte[] {0x2b,0x7e,0x15,0x16,0x28,0xae,0xd2,0xa6,0xab,0xf7,0x15,0x88,0x09,0xcf,0x4f,0x3c};
            AesCryp A = new AesCryp(key);
            Console.WriteLine("Insert message");
            string m = Console.ReadLine();
            List<byte[]> message = StringToAesBlocks(m);
            List<byte[]> Encryptmessage = new List<byte[]>();
            Console.WriteLine("encrypt message");
            foreach(byte[] i in message)
            {
                byte[] tmp = A.Encrypt(i);
                foreach(byte j in tmp)
                {
                    Console.Write(j + " ");
                }
                Encryptmessage.Add(A.Encrypt(i));
            }
            Console.WriteLine("\nDecrypt message");
            foreach(byte[] i in Encryptmessage)
            {
                byte[] tmp = A.Decrypt(i);
                Console.Write(Encoding.Default.GetString(tmp).TrimEnd());
            }
            Console.WriteLine();
        }
    }
}
