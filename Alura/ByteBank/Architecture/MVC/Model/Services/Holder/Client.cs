using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Holder
{
    public class Client
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Phone { get; private set; }
        public int Id { get; private set; }
        public static int Count { get; private set; } = 1;

        public Client(string name, string cpf, string phone)
        {
            try
            {
                this.Id = Count;
                this.Name = name;
                this.Cpf = FormatCPF(cpf);
                this.Phone = Convert.ToUInt64(phone.Trim()).ToString(@"00\ 0\ 0000\-0000");
                Count++;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string FormatCPF(string cpfToBeFormated)
        {
            string response = "";

            string[] newCPF = cpfToBeFormated.Replace('.', ' ').Replace('-', ' ').Split(' ');
            foreach (string word in newCPF)
                response += word;


            if (response.Length == 11)
            {
                response = response.Insert(9, "-");
                response = response.Insert(6, ".");
                response = response.Insert(3, ".");
            }
            else
                throw new Exception("Deu ruim ao criar " + this.Name + ". Invalid Cpf: " + cpfToBeFormated);


            return response;
        }

        public List<string> ClientData()
        {
            List<string> data = new List<string>();
            data.Add(this.Id.ToString());
            data.Add(this.Name);
            data.Add(this.Cpf);
            data.Add(this.Phone);

            return data;
        }
    }
}
