using Microsoft.Win32;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

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
            FileDialog.Filter = "pem |*.pem";
            if (FileDialog.ShowDialog() ?? false)
            {
                PrivateKeyPath.Value = FileDialog.FileName;
            }
        }

        private void BMPLoadButton_Click(object sender, RoutedEventArgs e)
        {
            var FileDialog = new OpenFileDialog();
            FileDialog.Filter = "bmp|*.bmp";
            if (FileDialog.ShowDialog() ?? false)
            {
                BMPPath.Value = FileDialog.FileName;
            }
        }

        private void SaveMessageToBmpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rsa.ImportPrivateKey(PrivateKeyPath.Value);

                var msg = rsa.EncryptStringRSA(MessageToEncryptTextBox.Text);

                BMPEditor.AddSecretToBmp(BMPPath.Value, msg);

                MessageBox.Show("Message added");
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PathToPublicKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var FileDialog = new OpenFileDialog();
            FileDialog.Filter = "pem|*.pem";
            if (FileDialog.ShowDialog() ?? false)
            {
                PublicKeyPath.Value = FileDialog.FileName;
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rsa.ImportPublicKey(PublicKeyPath.Value);

                var ecnryptmsg = BMPEditor.ReadSecretFromBmp(BMPPath.Value);

                DecryptedMessageTextBox.Text = rsa.DecryptStringRSA(ecnryptmsg);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SavePublicKeyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var FileDialog = new SaveFileDialog();
                FileDialog.Filter = "pem|*.pem";
                if (FileDialog.ShowDialog() ?? false)
                {
                    rsa.ImportPrivateKey(PrivateKeyPath.Value);
                    rsa.ExportPublicKey(FileDialog.FileName);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
