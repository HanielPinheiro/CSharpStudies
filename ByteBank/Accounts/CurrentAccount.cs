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
        public double payment { get; private set; }

        public CurrentAccount(int agencia, string conta, Client titular, double saldo)
        {
            try
            {
                this.agencie_number = agencia;
                this.account = conta;
                this.holder = titular;
                this.payment = saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid client! Error: " + ex.Message);
            }
        }

        public void Deposit(double valor)
        {
            this.payment += valor;
        }

        public void Withdraw(double valor)
        {
            this.payment -= valor;
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
            return this.payment;
        }

        public List<string> SeeHolder()
        {
            return this.holder.ClientData();
        }
    }
}
