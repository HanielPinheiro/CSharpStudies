using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.WinFormApp
{
    public partial class Read : Form
    {
        public Read(User user)
        {
            try
            {
                InitializeComponent();
                ShowData(user);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowData(User user)
        {
            try
            {
                Label_Id.Text = Convert.ToString(user.Id);
                Label_Name.Text = user.Name;
                Label_Email.Text = user.Age.ToString();
                Label_Email.Text = user.Email;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
