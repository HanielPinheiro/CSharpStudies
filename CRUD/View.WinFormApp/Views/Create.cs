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
        private readonly UserBLL manipulator;
        private static UserValidator businessRule = new UserValidator();
        public Create(UserBLL manipulatorReceived)
        {
            InitializeComponent();
            manipulator = manipulatorReceived;
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            if (VerifyName())
            {
                if (VerifyAge())
                {
                    if (VerifyPhone())
                    {
                        if (VerifyEmail())
                        {
                            if (manipulator.GetCount() < UserValidator.availableContacts)
                            {
                                User newUser = new User();
                                newUser.Id = manipulator.NextId();
                                newUser.Name = Field_Name.Text;
                                newUser.LastName = Field_LastName.Text;
                                newUser.Age = Convert.ToInt32(Field_Age.Text);
                                newUser.Email = Field_Email.Text;
                                newUser.Tel = long.Parse(Field_Phone.Text);
                                newUser.Country = Field_Country.Text;

                                manipulator.Create(newUser);
                                MessageBox.Show("User registered successfully");
                                this.Close();
                            }
                            else
                                MessageBox.Show("Impossible to create a new user, only " + UserValidator.availableContacts + "are permitted");
                        }
                        else
                            MessageBox.Show("Invalid Email");
                    }
                    else
                        MessageBox.Show("Invalid phone");
                }
                else
                    MessageBox.Show("Invalid age");
            }
            else
                MessageBox.Show("Invalid name");
        }

        private bool VerifyPhone()
        {
            string phone = Field_Phone.Text;
            if (businessRule.IsValidTel(phone))
                if (!manipulator.IsPhoneRegistered(long.Parse(phone)))
                    return true;
                else
                    return false;
            else
                return false;
        }

        private bool VerifyEmail()
        {
            string email = Field_Email.Text;
            if (businessRule.IsValidEmail(email))
                if (!manipulator.IsEmailRegistered(email))
                    return true;
                else
                    return false;
            else
                return false;
        }

        private bool VerifyAge()
        {
            string age = Field_Age.Text;
            if (businessRule.IsValidAge(age))
                return true;
            else
                return false;
        }

        private bool VerifyName()
        {
            string name = Field_Name.Text;
            if (name?.Length > 0)
                return true;
            else
                return false;
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            Field_Name.Text = "";
            Field_LastName.Text = "";
            Field_Age.Text = "";
            Field_Email.Text = "";
            Field_Phone.Text = "";
            Field_Country.Text = "";
        }
    }
}
