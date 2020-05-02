using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсовая.GIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RSACryptoServiceProvider rsa { get; set; } = new RSACryptoServiceProvider();

        public ValueContainer<string> PrivateKeyPath { get; set; } = new ValueContainer<string>("Set path");

        public ValueContainer<string> PublicKeyPath { get; set; } = new ValueContainer<string>("Set path");

        public ValueContainer<string> BMPPath { get; set; } = new ValueContainer<string>("Set path");


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void PrivateKeyLoadButton_Click(object sender, RoutedEventArgs e)
        {
            var FileDialog = new OpenFileDialog();
            if (FileDialog.ShowDialog() ?? false)
            {
                PrivateKeyPath.Value = FileDialog.FileName;
            }
        }

        private void BMPLoadButton_Click(object sender, RoutedEventArgs e)
        {
            var FileDialog = new OpenFileDialog();
            if (FileDialog.ShowDialog() ?? false)
            {
                BMPPath.Value = FileDialog.FileName;
            }
        }

        private void SaveMessageToBmpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rsa.ImportPrivateKeyFromPcksPEM(PrivateKeyPath.Value);

                var msg = rsa.EncryptStringRSA(MessageToEncryptTextBox.Text);

                BMPEditor.AddSecretToBmp(BMPPath.Value, msg);

                MessageBox.Show("Message added");
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PathToPublicKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var FileDialog = new OpenFileDialog();
            if (FileDialog.ShowDialog() ?? false)
            {
                PublicKeyPath.Value = FileDialog.FileName;
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rsa.ImportPublicKeyFromPcksPEM(PublicKeyPath.Value);

                var ecnryptmsg = BMPEditor.ReadSecretFromBmp(BMPPath.Value);

                DecryptedMessageTextBox.Text = rsa.DecryptStringRSA(ecnryptmsg);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SavePublicKeyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var encoder = new UnicodeEncoding();
                var FileDialog = new SaveFileDialog();
                FileDialog.Filter = "txt|*.txt";
                if (FileDialog.ShowDialog() ?? false)
                {
                    rsa.ImportPrivateKeyFromPcksPEM(PrivateKeyPath.Value);
                    using var file = new FileStream(FileDialog.FileName, FileMode.OpenOrCreate);
                    using var sw = new StreamWriter(file);
                    sw.WriteLine("-----BEGIN PUBLIC KEY-----");
                    sw.WriteLine(Convert.ToBase64String(rsa.ExportRSAPublicKey()));
                    sw.WriteLine("-----END PUBLIC KEY-----");
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
