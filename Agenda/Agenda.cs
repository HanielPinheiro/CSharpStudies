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
    public partial class Agenda : Form
    {
        private List<Contatos> contatosAgenda = new List<Contatos>();
        public Agenda()
        {
            InitializeComponent();
            inserirContatos();
            
        }

        private void inserirContatos()
        {
            contatosAgenda.Add(criarContatos(1, "João", "da Silva", "joao_daSilva@gmail.com", "11 99854-5588","A"));
            contatosAgenda.Add(criarContatos(2, "Antonio", "Nunes", "tonin.Nunes@gmail.com", "11 93325-4477","A"));
            contatosAgenda.Add(criarContatos(3, "Flavio", "Aroucha", "flaio.Aroucha@gmail.com", "11 98875-6547", "B"));
            contatosAgenda.Add(criarContatos(4, "Eliana", "das Flores", "eli.Flores@gmail.com", "11 98577-3312", "C"));

            gridData.DataSource = contatosAgenda.OrderBy(p => p.Name.ToString()).ToList();   
        }

        private Contatos criarContatos(int id, string name, string lastName, string email, string tel, string org)
        {
            Contatos contato = new Contatos();
            contato.Id = id;
            contato.Name = name;
            contato.LastName = lastName;
            contato.Email = email;
            contato.Tel = tel;
            contato.Organizacao = org.ToUpper();

            return contato;
        }

        private void alterarDadosGrid(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;                        
            var data = gridData.Rows[idx].Cells["Id"].Value;
            MessageBox.Show(data.ToString());
        }
    }
}
