using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GIS2
{
    public enum CountOfColors
    {
        Color16 = 16,
        Color256 = 256
    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load(this.img, "COLOR16.MTX", CountOfColors.Color16);
            Load(this.img2, "COLOR256.MTX", CountOfColors.Color256);
        }

        void Load(Image img, string path, CountOfColors colors, bool invert = false)
        {
            var data = File.ReadAllBytes(path);
            img.Source = ReadBmp(640, 480, data, colors, invert);
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        BitmapSource Cut(string path)
        {
            var data = File.ReadAllBytes(path);
            List<byte> newdata = new List<byte>(data.Length);

            for (int i = 100; i < 202; i++)
            {
                newdata.AddRange(data.ToList().Skip(320 * i + 269).Take(51));
            }
            return ReadBmp(102, 102, newdata.ToArray(), CountOfColors.Color16, false);
        }

        BitmapPalette InvertPalette(BitmapPalette src)
        {
            List<Color> colors = new List<Color>();

            foreach (var i in src.Colors)
                colors.Add(Color.FromRgb((byte)(255 - i.R), (byte)(255 - i.G), (byte)(255 - i.B)));

            return new BitmapPalette(colors);
        }

        public BitmapSource ReadBmp(int width, int height, byte[] data, CountOfColors colorCount, bool invert = false)
        {
            BitmapPalette palette;
            int stride;
            PixelFormat pixelFormat;

            switch ((int)colorCount)
            {
                case 16:
                    palette = invert == false ? BitmapPalettes.Gray16 : InvertPalette(BitmapPalettes.Gray16);
                    stride = width / 2;
                    pixelFormat = PixelFormats.Indexed4;
                    break;
                case 256:
                    palette = invert == false ? BitmapPalettes.Gray256 : InvertPalette(BitmapPalettes.Gray256);
                    stride = width;
                    pixelFormat = PixelFormats.Indexed8;
                    break;
                default:
                    throw new Exception("Unknown format");
            }
            BitmapSource result = BitmapSource.Create(width, height, 96, 96, pixelFormat, palette, data, stride);
            result.Freeze();
            return new TransformedBitmap(result, new ScaleTransform(1, -1));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) => Load(this.img, "COLOR16.MTX", CountOfColors.Color16, true);

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e) => Load(this.img2, "COLOR256.MTX", CountOfColors.Color256, true);

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) => Load(this.img, "COLOR16.MTX", CountOfColors.Color16, false);

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e) => Load(this.img2, "COLOR256.MTX", CountOfColors.Color256, false);

        private void Button_Click(object sender, RoutedEventArgs e) => SaveBMP(img.Source as BitmapSource, "mtrx16.bmp");

        private void Button_Click_1(object sender, RoutedEventArgs e) => SaveBMP(img2.Source as BitmapSource, "mtrx256.bmp");


        void SaveBMP(BitmapSource img, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(img));
                encoder.Save(stream);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) => new ShowImg(Cut("COLOR16.MTX")).Show();
    }
}
