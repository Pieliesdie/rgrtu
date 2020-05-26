using Microsoft.Win32;
using Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace KursovayaGIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte[] data;
        EncryptedBlock<byte>[] encryptedBlocks;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";
            if (openFileDialog1.ShowDialog() ?? false)
            {
                data = File.ReadAllBytes(openFileDialog1.FileName);
                Picture.Source = new BitmapImage(new Uri(openFileDialog1.FileName));
                SizeTextBlock.Text = data.Length.ToString() + " байт";
            }
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (data == null)
            {
                MessageBox.Show("Загрузите изображение");
                return;
            }
            Int32.TryParse(SizeTextBox.Text, out var size);
            size = size > 0 ? size : 500;
            var message = data.Split(size).ToArray();
            var result = new EncryptedBlock<byte>[message.Count()];
            Parallel.For(0, message.Count(), (i) =>
            {
                var encoded = ArithmeticCoder.Encode(message[i].ToArray());
                result[i] = new EncryptedBlock<byte>(encoded.Message, encoded.Ranges, encoded.Length);
            });
            MessageBox.Show("Изображение закодировано");
            encryptedBlocks = result;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (encryptedBlocks == null)
            {
                MessageBox.Show("Закодируйте изображение");
                return;
            }
            var a = encryptedBlocks[0].Message.GetWholePart();
            BinaryFormatter formatter = new BinaryFormatter();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Encoded files(*.dat)|*.dat";
            if (saveFileDialog.ShowDialog() ?? false)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    //formatter.Serialize(fs, encryptedBlocks);
                    fs.Write(Parser.Encode(encryptedBlocks));
                    SizeCodedTextBlock.Text = fs.Length.ToString() + " байт";
                    MessageBox.Show("Обьект сохранен");
                }
            }

        }

        private void OpenEncodeButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Encoded files(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() != true)
                return;

            BinaryFormatter formatter = new BinaryFormatter();
            //read file
            //using FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            EncryptedBlock<byte>[] encrypteds = Parser.Decode(File.ReadAllBytes(openFileDialog1.FileName));//(EncryptedBlock<byte>[])formatter.Deserialize(fs);

            //decode
            IEnumerable<byte>[] result = new IEnumerable<byte>[encrypteds.Length];
            Parallel.For(0, encrypteds.Count(), (i) =>
            {
                var temp = encrypteds[i];
                var encoded = ArithmeticCoder.Decode(temp.Message, temp.Ranges, temp.Length);
                result[i] = encoded;
            });

            //merge
            using MemoryStream image = new MemoryStream();
            foreach (var i in result)
                image.Write(i.ToArray(), 0, i.Count());


            var img = ConvertByteArrayToBitmapImage(image.ToArray());
            EncodedPicture.Source = img;
        }

        public static BitmapImage ConvertByteArrayToBitmapImage(Byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
