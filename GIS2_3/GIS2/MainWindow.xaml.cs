using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GIS2
{
    public partial class MainWindow : Window
    {
        byte[] data => File.ReadAllBytes("COLOR256.MTX");

        public MainWindow()
        {
            InitializeComponent();
            Load(this.img, "COLOR16.MTX", CountOfColors.Color16);
            Load(this.img2, "COLOR256.MTX", CountOfColors.Color256);

        }

        void Load(Image img, string path, CountOfColors colors)
        {
            var data = File.ReadAllBytes(path);
            img.Source = ReadBmp(640, 480, data, colors);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            img2.Source = Scale(img2.Source as BitmapSource, double.Parse(scaleX.Text), double.Parse(scaleY.Text));
        }

        private static double Lerp(double s, double e, double t)
        {
            return s + (e - s) * t;
        }

        private static double Blerp(double c00, double c10, double c01, double c11, double tx, double ty)
        {
            return Lerp(Lerp(c00, c10, tx), Lerp(c01, c11, tx), ty);
        }

        private static BitmapSource Scale(BitmapSource self, double scaleX, double scaleY)
        {
            if (self.Format != PixelFormats.Indexed8 && self.Palette != BitmapPalettes.Gray256)
                throw new Exception("Unsupported");

            int oldWidth = (int)self.Width;
            int oldHeight = (int)self.Height;
            byte[] old = new byte[oldWidth * oldHeight];
            self.CopyPixels(old, oldWidth, 0);
            var old2d = new D2<byte>(old, oldWidth);


            int newWidth = (int)(oldWidth * scaleX);
            int newHeight = (int)(oldHeight * scaleY);
            byte[] _newimg = new byte[newHeight * newWidth];
            var newimg = new D2<byte>(_newimg, newWidth);

            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    double gx = ((double)x) / newWidth * (oldWidth - 1);
                    double gy = ((double)y) / newHeight * (oldHeight - 1);
                    int gxi = (int)(gx);
                    int gyi = (int)(gy);

                    double c00 = old2d[gyi, gxi];
                    double c10 = old2d[gyi, gxi + 1];
                    double c01 = old2d[gyi + 1, gxi];
                    double c11 = old2d[gyi + 1, gxi + 1];

                    byte newColor = (byte)Blerp(c00, c10, c01, c11, gx - gxi, gy - gyi);
                    newimg[y, x] = newColor;
                }
            }

            var result = BitmapSource.Create(newWidth, newHeight, 96, 96, self.Format, self.Palette, newimg.input, newWidth);
            result.Freeze();
            return result;
        }


        BitmapPalette ContrastPallete(BitmapPalette src, byte ymin, byte ymax)
        {
            byte f(byte x)
            {
                var result = (double)255 / (ymax - ymin) * (x - ymin);

                result = result > 255 ? 255 : result;
                result = result < 0 ? 0 : result;

                return (byte)result;
            }


            List<Color> colors = new List<Color>();

            foreach (var i in src.Colors)
                colors.Add(Color.FromRgb(f(i.R), f(i.G), f(i.B)));

            return new BitmapPalette(colors);
        }


        BitmapSource Cut(string path)
        {
            var data = File.ReadAllBytes(path);
            List<byte> newdata = new List<byte>(data.Length);

            for (int i = 100; i < 202; i++)
            {
                newdata.AddRange(data.ToList().Skip(320 * i + 269).Take(51));
            }
            return ReadBmp(102, 102, newdata.ToArray(), CountOfColors.Color16);
        }

        BitmapPalette InvertPalette(BitmapPalette src)
        {
            List<Color> colors = new List<Color>();

            foreach (var i in src.Colors)
                colors.Add(Color.FromRgb((byte)(255 - i.R), (byte)(255 - i.G), (byte)(255 - i.B)));

            return new BitmapPalette(colors);
        }

        public BitmapSource ReadBmp(int width, int height, byte[] data, CountOfColors colorCount)
        {
            BitmapPalette palette;
            int stride;
            PixelFormat pixelFormat;

            switch ((int)colorCount)
            {
                case 16:
                    palette = BitmapPalettes.Gray16;
                    stride = width / 2;
                    pixelFormat = PixelFormats.Indexed4;
                    break;
                case 256:
                    palette = BitmapPalettes.Gray256;
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


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BitmapSource result = BitmapSource.Create(640, 480, 96, 96, PixelFormats.Indexed8, ContrastPallete(BitmapPalettes.Gray256, (byte)ymin.Value, (byte)ymax.Value), data, 640);
            result.Freeze();
            result = new TransformedBitmap(result, new ScaleTransform(1, -1));
            img2.Source = result;
        }

    }
}
