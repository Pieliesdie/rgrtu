using digital_signature_RSA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RSA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void GenerateKeys_button_Click(object sender, EventArgs e)
        {
            try
            {
                int q = Int32.Parse(q_maskedTextBox.Text);
                int p = Int32.Parse(p_maskedTextBox.Text);
                RSAProvider rsa = new RSAProvider(p, q);
                PublicKey_textBox.Text = rsa.PublicKeyE.ToString();
                Private_key_textBox.Text = rsa.PrivateKey.ToString();
                Mod_textBox.Text = rsa.PublicKeyN.ToString();
            }
            catch
            {
                MessageBox.Show("smthing wrong");
            }
        }

        private void Encrypt_button_Click(object sender, EventArgs e)
        {
            try
            {
                long mod = long.Parse(ModToEncr_textBox.Text);
                if (mod < 128)
                {
                    MessageBox.Show("small mod");
                    return;
                }
                long e_ = long.Parse(PublicKeyToEncr_textBox.Text);
                var msg = Encoding.Default.GetBytes(message_richTextBox.Text);
                List<long> encrrmsg = new List<long>();

                string tmp = string.Empty;
                foreach (byte i in msg)
                {
                    long encrblock = RSAProvider.Encrypt(i, e_, mod);
                    encrrmsg.Add(encrblock);
                    tmp += encrblock.ToString() + "\t";
                }

                message_richTextBox.Text = tmp;
            }
            catch
            {
                MessageBox.Show("smthing wrong");
            }
        }

        private void Decrypt_button_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = Encrmsg_richTextBox.Text;
                var tmp = Regex.Matches(msg, @"\d+").Cast<Match>().Select(x => x.ToString()).ToArray();
                List<long> encrmsg = new List<long>();
                foreach (string i in tmp)
                {
                    encrmsg.Add(long.Parse(i));
                }

                byte[] decrmsg = new byte[encrmsg.Count()];
                for (int i = 0; i < decrmsg.Length; i++)
                {
                    decrmsg[i] = (byte)RSAProvider.Decrypt(encrmsg[i],
                        long.Parse(PrivateKeyToDecr_textBox.Text),
                        long.Parse(ModToDecr_textBox.Text));
                }
                Encrmsg_richTextBox.Text = Encoding.Default.GetString(decrmsg);
            }
            catch
            {
                MessageBox.Show("smthing wrong");
            }
        }
    }
}
