using ByteBank.Holder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class CurrentAccount
    {
        public int agencie_number { get; private set; }
        public string account { get; private set; }
        public Client holder { get; private set; }
        public double wage { get; private set; }
        public int Agencie { get; }

        public CurrentAccount(int agencie, string account, Client holder, double balance)
        {
            try
            {
                this.agencie_number = agencie;
                this.account = account;
                this.holder = holder;
                this.wage = balance;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid client! Error: " + ex.Message);
            }
            Agencie = agencie;
        }

        public void Deposit(double valor)
        {
            this.wage += valor;
        }

        public void Withdraw(double valor)
        {
            this.wage -= valor;
        }

        public int SeeAgencie()
        {
            return this.agencie_number;
        }

        public string SeeAccount()
        {
            return this.account;
        }

        public double SeeBalance()
        {
            return this.wage;
        }

        public List<string> SeeHolder()
        {
            return this.holder.ClientData();
        }
    }
}
