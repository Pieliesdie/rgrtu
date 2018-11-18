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
    public partial class UserRewardsForm : Form
    {
        private int _id;
        //public UserRewardsForm()
        //{
        //    InitializeComponent();
        //}
       
        public UserRewardsForm(int id,IMemory memory)
        {
            InitializeComponent();
            _id = id;
            dataGridView1.DataSource = memory.GetUserRewardsByID(id);
            this.Show();
        }
    }
}
