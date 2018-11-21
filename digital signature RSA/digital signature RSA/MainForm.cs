using System;
using System.Windows.Forms;

namespace digital_signature_RSA
{

    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            int p = Int32.Parse(P_maskedTextBox1.Text);
            int q = Int32.Parse(Q_maskedTextBox2.Text);
            if (!(MathHelp.IsPrime(p) && MathHelp.IsPrime(q)))
            {
                MessageBox.Show("Numbers are not simple");
                return;
            }
            var RSA = new RSAProvider(p, q);
            long n = RSA.PublicKeyN;
            long e_ = RSA.PublicKeyE;
            long d = RSA.PrivateKey;

            long hash = Message_richTextBox.Text.GetHashCode() % n;

            Hash_richTextBox.Text = RSAProvider.Encrypt(hash, d, n).ToString();

            Hash_richTextBox3.Text = Hash_richTextBox.Text;
            Message_richTextBox4.Text = Message_richTextBox.Text;
            E_maskedTextBox3.Text = e_.ToString();
            N_maskedTextBox4.Text = n.ToString();
            E_maskedTextBox6.Text = e_.ToString();
            N_maskedTextBox5.Text = n.ToString();


        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            long e_ = Int64.Parse(E_maskedTextBox6.Text);
            long n = Int64.Parse(N_maskedTextBox5.Text);

            long hash = Message_richTextBox4.Text.GetHashCode() % n;
            long InputHash = RSAProvider.Decrypt(Int64.Parse(Hash_richTextBox3.Text), e_, n);

            if (hash == InputHash)
            {
                MessageBox.Show("Digital signature is correct");
            }
            else
            {
                MessageBox.Show("Digital signature is incorrect");
            }
        }
    }
}
