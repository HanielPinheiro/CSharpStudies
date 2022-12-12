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
        public string name { get; private set; }
        public string cpf { get; private set; }
        public string phone { get; private set; }
        public int id { get; private set; }
        public static int count { get; private set; } = 0;

        public Client(string name, string cpf, string phone)
        {
            try
            {
                this.id = count;
                this.name = name;
                this.cpf = FormatCPF(cpf);
                this.phone = Convert.ToUInt64(phone.Trim()).ToString(@"00\ 0\ 0000\-0000");
                count++;
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
                throw new Exception("Deu ruim ao criar " + this.name + ". Invalid Cpf: " + cpfToBeFormated);


            return response;
        }

        public List<string> ClientData()
        {
            List<string> data = new List<string>();
            data.Add(this.id.ToString());
            data.Add(this.name);
            data.Add(this.cpf);
            data.Add(this.phone);

            return data;
        }
    }
}
