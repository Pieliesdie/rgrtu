using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class MainForm : Form
    {
        IMemory _memory;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddRewardsButtons()
        {
            DataGridViewButtonColumn ButtonColumn = new DataGridViewButtonColumn();
            ButtonColumn.Text = "Open";
            ButtonColumn.Name = "Rewards";
            ButtonColumn.HeaderText = "Rewards";
            ButtonColumn.UseColumnTextForButtonValue = true;
            ButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(ButtonColumn);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _memory = new MemoryProvider();
        }

        private void UpdateTables()
        {
            dataGridView1.Columns.Clear();
            var users = _memory.GetUsers();
            var rewards = _memory.GetRewards();
            dataGridView1.DataSource = users;
            dataGridView2.DataSource = rewards;
            AddRewardsButtons();
        }

        private void dataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _memory = new DBProvider();
            UpdateTables();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                UserRewardsForm rewardsForm = new UserRewardsForm((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value,_memory);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UserMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                _memory.DeleteUser((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            UpdateTables();
        }
    }
}
