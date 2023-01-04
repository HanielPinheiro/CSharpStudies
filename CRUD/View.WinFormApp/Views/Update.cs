using Business;
using Model;
using System;
using System.Windows.Forms;

namespace View.WinFormApp
{
    public partial class Update : Form
    {
        private User targetUser, cloneUser;
        private readonly UserBLL localDataManipulator;

        public Update(User user, UserBLL manipulator)
        {
            try
            {
                InitializeComponent();
                targetUser = user;
                cloneUser = user;
                localDataManipulator = manipulator;
                SetFields();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetFields()
        {
            try
            {
                Field_Name.Text = cloneUser.Name;
                Field_Age.Text = cloneUser.Age.ToString();
                Field_Email.Text = cloneUser.Email;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                SetFields();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            try
            {
                targetUser.Id = cloneUser.Id;
                targetUser.Name = Field_Name.Text;
                targetUser.Age = Convert.ToInt32(Field_Age.Text);
                targetUser.Email = Field_Email.Text;
                localDataManipulator.Update(targetUser);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
