using BLL;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var bd = new DBProvider();
            var user = bd.GetUsers();
            dataGridView1.DataSource = user;
        }

        private void Relaitions_Click(object sender, EventArgs e)
        {

        }
    }
}
