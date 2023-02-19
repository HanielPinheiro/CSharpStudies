using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Investimentos
{
    public class Conta
    {
        private string cliente;
        private int agencia;
        private string conta;
        private double saldo = 0d;

        public Conta(string cliente, int agencia, string conta)
        {
            this.cliente= cliente;
            this.agencia= agencia;
            this.conta = conta;
        }

        public double ConsultarSaldo()
        {
            return saldo;
        }

        public bool Depositar(double valorDeposito)
        {
            if (valorDeposito > 0)
            {
                this.saldo += valorDeposito;
                return true;
            }

            return false;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.saldo >= valorSaque)
            {
                this.saldo -= valorSaque;
                return true;
            }

            return false;
        }
    }
}
