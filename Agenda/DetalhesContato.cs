using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudandoC_Sharp
{
    public partial class DetalhesContato : Form
    {
        private Contatos contatoAtual;
        private Contatos dadosAtt;
        public DetalhesContato(Contatos subject)
        {
            InitializeComponent();
            contatoAtual = subject;
            dadosAtt = subject;
            PutDataOnFields();
        }

        private void PutDataOnFields()
        {
            Field_Name.Text = contatoAtual.Name;
            Field_LastName.Text = contatoAtual.LastName;
            Field_Email.Text = contatoAtual.Email;
            Field_Organization.Text = contatoAtual.Organization;
            Field_Tel.Text = contatoAtual.Tel;
            Field_FullName.Text = "FullName: " + contatoAtual.Name + " " + contatoAtual.LastName;
        }

        private void Field_Name_TextChanged(object sender, EventArgs e)
        {
            contatoAtual.Name = Field_Name.Text;
            Field_FullName.Text = "FullName: " + contatoAtual.Name +" "+ contatoAtual.LastName;
        }      

        private void Field_LastName_TextChanged(object sender, EventArgs e)
        {
            contatoAtual.LastName = Field_LastName.Text;
            Field_FullName.Text = "FullName: " + contatoAtual.Name + " " + contatoAtual.LastName;
        }

        private void Field_Tel_TextChanged(object sender, EventArgs e)
        {
            contatoAtual.Tel = Field_Tel.Text;
        }

        private void Field_Email_TextChanged(object sender, EventArgs e)
        {
            contatoAtual.Email = Field_Email.Text;
        }

        private void Field_Organization_TextChanged(object sender, EventArgs e)
        {
            contatoAtual.Organization = Field_Organization.Text;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Btn_Atualizar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
