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
            InitializeComponent();
            ShowData(user);
        }

        public void ShowData(User user)
        {
            Label_Id.Text = Convert.ToString(user.Id);
            Label_Name.Text = user.Name;
            Label_LastName.Text = user.LastName;
            Label_Age.Text = Convert.ToString(user.Age);
            Label_Phone.Text = Convert.ToString(user.Tel);
            Label_Email.Text = user.Email;
            Label_Country.Text = user.Country;
        }
    }
}
