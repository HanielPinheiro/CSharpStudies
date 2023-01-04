using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.WinFormApp
{
    public partial class Delete : Form
    {
        private readonly UserBLL localDataManipulator;
        public Delete()
        {
            localDataManipulator = new UserBLL();
        }

        int targetId = 0;

        public Delete(int id, string email, UserBLL manipulator)
        {
            try
            {
                InitializeComponent();
                Label_Message.Text = "Do you really want to delete this user: " + id + " - " + email;
                localDataManipulator = manipulator;
                targetId = id;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Yes_Click(object sender, EventArgs e)
        {
            try
            {
                localDataManipulator.Delete(targetId);
                MessageBox.Show("User delete successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void Button_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
