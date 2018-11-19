using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class UserRewardsForm : Form
    {
        private int _id;
        private IMemory _memory;
        //public UserRewardsForm()
        //{
        //    InitializeComponent();
        //}
       
        public UserRewardsForm(int id,IMemory memory)
        {
            InitializeComponent();
            _id = id;
            _memory = memory;
            dataGridView1.DataSource = memory.GetUserRewardsByID(id);
            this.Show();
        }

        private void addNewRewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Insert IDs of rewards\nFormat:\n1,2,3..","Rewards");
            if(!String.IsNullOrEmpty(result))
            {
                var rewardIDs = Regex.Matches(result, @"\d+").Cast<Match>().Select(x => Int32.Parse(x.Value)).ToList();
                _memory.AddRewardToUser(_id, rewardIDs);
                dataGridView1.DataSource = _memory.GetUserRewardsByID(_id);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UserRewardsMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _memory.DeleteRewardFromUser(_id,(int)dataGridView1.SelectedRows[0].Cells[0].Value);
            dataGridView1.DataSource = _memory.GetUserRewardsByID(_id);
        }
    }
}
