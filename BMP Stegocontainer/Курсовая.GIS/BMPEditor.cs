﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Курсовая.GIS
{
    public static class BMPEditor
    {
        public static byte[] ReadSecretFromBmp(string path) => ReadSecretFromBmp(File.ReadAllBytes(path));

        public static void AddSecretToBmp(string path, byte[] secret)
        {
            var src = File.ReadAllBytes(path);
            var srcWithSecret = AddSecretToBmp(src, secret);
            File.WriteAllBytes(path, srcWithSecret);
        }

        private static byte[] ReadSecretFromBmp(byte[] bmp)
        {
            const int FileHeaderSize = 14;
            var offset = BitConverter.ToInt32(bmp.Skip(10).Take(4).ToArray());
            var bitmapInfoSize = BitConverter.ToInt32(bmp.Skip(0xE).Take(4).ToArray());

            var normalOffset = FileHeaderSize + bitmapInfoSize + GetColorTableSize(bmp); 
            var secretLength = offset - normalOffset;

            return bmp.Skip(normalOffset).Take(secretLength).ToArray();
        }

        private static int GetColorTableSize(byte[] bmp)
        {
            var bitmapInfoSize = BitConverter.ToInt32(bmp.Skip(0xE).Take(4).ToArray());
            short bpp;
            if (bitmapInfoSize == 12)
            {
                bpp = BitConverter.ToInt16(bmp.Skip(0x18).Take(2).ToArray());
            }
            else
            {
                bpp = BitConverter.ToInt16(bmp.Skip(0x1C).Take(2).ToArray());
            }
            return bpp <= 8 ? ((int)Math.Pow(2, bpp) * 4) : 0;
        }

        private static byte[] AddSecretToBmp(byte[] bmp, byte[] secret)
        {
            const int FileHeaderSize = 14;
            var bfType = bmp.Take(2);
            var bfReserved12 = bmp.Skip(6).Take(4);
            var offset = BitConverter.ToInt32(bmp.Skip(10).Take(4).ToArray());
            var pixels = bmp.Skip(offset);
            var bitmapInfoSize = BitConverter.ToInt32(bmp.Skip(0xE).Take(4).ToArray());
            var colorTableSize = GetColorTableSize(bmp);
            var newoffset = FileHeaderSize + bitmapInfoSize + secret.Length + colorTableSize;
            var newbfSize = FileHeaderSize + secret.Length + BitConverter.ToInt32(bmp.Skip(0xE).Take(4).ToArray()) + colorTableSize + pixels.Count();

            var newBmp = new List<byte>();

            newBmp.AddRange(bfType);
            newBmp.AddRange(BitConverter.GetBytes(newbfSize));
            newBmp.AddRange(bfReserved12);
            newBmp.AddRange(BitConverter.GetBytes(newoffset));
            newBmp.AddRange(bmp.Skip(FileHeaderSize).Take(bitmapInfoSize + colorTableSize));
            newBmp.AddRange(secret);
            newBmp.AddRange(pixels);

            return newBmp.ToArray();
        }
    }
}
