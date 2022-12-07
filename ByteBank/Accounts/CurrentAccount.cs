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
        private int numero_agencia;
        private string conta;
        private Client titular;
        private double saldo;

        public CurrentAccount(int agencia, string conta, Client titular, double saldo)
        {
            try
            {
                this.numero_agencia = agencia;
                this.conta = conta;
                this.titular = titular;
                this.saldo = saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid client!");
            }
        }

        public void Deposit(double valor)
        {
            this.saldo += valor;
        }

        public void Withdraw(double valor)
        {
            this.saldo -= valor;
        }

        public int SeeAgencie()
        {
            return this.numero_agencia;
        }

        public string SeeAccount()
        {
            return this.conta;
        }

        public double SeeBalance()
        {
            return this.saldo;
        }

        public List<string> SeeHolder()
        {
            return this.titular.ClientData();
        }
    }
}
