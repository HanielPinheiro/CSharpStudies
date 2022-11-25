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

namespace Presentation.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = Field_Name.Text;
            int idade = Convert.ToInt32(Field_Idade.Text);

            User user = new User();
            user.Name = name;
            user.Age = idade;

            UserValidate userValidate = new UserValidate();
            bool isValid = userValidate.IsValid(user);

            if (isValid)
            {
                Field_Result.Text = "deu bom";
            }
            else
            {
                Field_Result.Text = "deu ruim";
            }
        }
    }
}
