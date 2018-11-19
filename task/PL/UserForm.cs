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
    public partial class UserForm : Form
    {
        Common.Users user;
        MainForm parent;
        IMemory memory;
        public UserForm(MainForm parent,IMemory memory)
        {
            this.parent = parent;
            this.memory = memory;
            InitializeComponent();
        }
        public UserForm(MainForm parent, IMemory memory,Common.Users user)
        {
            this.parent = parent;
            this.memory = memory;
            this.user = user;
            InitializeComponent();
            if (user != null)
            {
                FirstName.Text = user.FirstName;
                LastName.Text = user.LastName;
                birthdate.Text = user.Birthday.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (FirstName != null && birthdate != null&& birthdate.ValidateText()!=null)
            {
                if (user == null)
                {
                    memory.AddUser(new Common.Users()
                    {
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        Birthday = (DateTime)birthdate.ValidateText()
                    });
                }
                else
                {
                    bool ok = memory.UpdateUser(new Common.Users()
                    {
                        ID = user.ID,
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        Birthday = (DateTime)birthdate.ValidateText()
                    });
                }
                parent.UpdateTables();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect values");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
