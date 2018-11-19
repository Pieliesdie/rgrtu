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
            if (memoryToolStripMenuItem.Checked == false)
            {
                memoryToolStripMenuItem.Checked = true;
                dataBaseToolStripMenuItem.Checked = false;
                _memory = new MemoryProvider();
                UpdateTables();
            }
        }

        public void UpdateTables()
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
            if (dataBaseToolStripMenuItem.Checked == false)
            {
                dataBaseToolStripMenuItem.Checked = true;
                memoryToolStripMenuItem.Checked = false;
                _memory = new DBProvider();
                UpdateTables();
            }
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

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_memory == null)
            {
                MessageBox.Show("choose data source");
            }
            else
            new UserForm(this,_memory).Show();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UserForm(this, _memory, new Common.Users()
            {
                ID = (int)dataGridView1.SelectedRows[0].Cells[0].Value,
                FirstName = (string)dataGridView1.SelectedRows[0].Cells[1].Value,
                LastName = (string)dataGridView1.SelectedRows[0].Cells[2].Value,
                Birthday = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())
            }).Show();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RewardMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void addNewRewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_memory == null)
            {
                MessageBox.Show("choose data source");
            }
            else
            new RewardForm(this, _memory).Show();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {
                _memory.DeleteReward((int)dataGridView2.SelectedRows[0].Cells[0].Value);
            }
            UpdateTables();
        }

        private void changeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new RewardForm(this, _memory, new Common.Rewards()
            {
                ID = (int)dataGridView2.SelectedRows[0].Cells[0].Value,
                Title = (string)dataGridView2.SelectedRows[0].Cells[1].Value,
                Decription = (string)dataGridView2.SelectedRows[0].Cells[2].Value,
            }).Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_memory != null)
            {
                UpdateTables();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RSREU,2018");
        }
    }
}
