using Business;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View.WinFormApp
{
    public partial class Update : Form
    {
        User targetUser, cloneUser;
        DataManipulation localDataManipulator;

        public Update(User user, DataManipulation manipulator)
        {
            InitializeComponent();
            targetUser = user;
            cloneUser = user;
            localDataManipulator = manipulator;
            SetFields();
        }

        public void SetFields()
        {
            Field_Name.Text = cloneUser.Name;
            Field_LastName.Text = cloneUser.LastName;
            Field_Age.Text = cloneUser.Age.ToString();
            Field_Email.Text = cloneUser.Email;
            Field_Phone.Text = cloneUser.Tel.ToString();
            Field_Country.Text = cloneUser.Country;
            localDataManipulator.Update(cloneUser, cloneUser.Id);
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            SetFields();
            this.Close();
        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            targetUser.Name = Field_Name.Text;
            targetUser.LastName = Field_LastName.Text;
            targetUser.Age = Convert.ToInt32(Field_Age.Text);
            targetUser.Email = Field_Email.Text;
            targetUser.Tel = long.Parse(Field_Phone.Text);
            targetUser.Country = Field_Country.Text;
            localDataManipulator.Update(targetUser, cloneUser.Id);
            this.Close();
        }
    }
}
