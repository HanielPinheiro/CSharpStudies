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
    public partial class Create : Form
    {
        private readonly UserBLL localDataManipulator;
        private readonly UserValidator localValidator;

        public Create(UserBLL manipulatorReceived)
        {
            try
            {
                InitializeComponent();
                localDataManipulator = manipulatorReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsParametersValids())
                    CreateUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsParametersValids()
        {
            try
            {
                if (!IsNameValid())
                {
                    MessageBox.Show("Invalid Name");
                    return false;
                }

                if (!IsAgeValid())
                {
                    MessageBox.Show("Invalid Age");
                    return false;
                }

                if (!IsEmailValid())
                {
                    MessageBox.Show("Invalid Email");
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateUser()
        {
            try
            {
                if (localDataManipulator.CountUsers() < UserValidator.availableContacts)
                {
                    User newUser = new User();
                    newUser.Id = -1;
                    newUser.Name = Field_Name.Text;
                    newUser.Age = Convert.ToInt32(Field_Age.Text);
                    newUser.Email = Field_Email.Text;

                    localDataManipulator.Create(newUser);

                    MessageBox.Show("User registered successfully");

                    this.Close();
                }
                else
                    MessageBox.Show("Impossible to create a new user, only " + UserValidator.availableContacts + "are permitted");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsEmailValid()
        {
            try
            {
                string email = Field_Email.Text;
                if (localValidator.IsValidEmail(email))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsAgeValid()
        {
            try
            {
                string age = Field_Age.Text;
                if (localValidator.IsValidAge(age))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsNameValid()
        {
            try
            {
                string name = Field_Name.Text;
                if (name?.Length > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            Field_Name.Text = "";
            Field_Age.Text = "";
            Field_Email.Text = "";
        }

    }
}
