using System;

namespace DesignPatterns.Investimentos
{
    public class Conta
    {
        public string Cliente { get; set; }
        public int Agencia { get; set; }
        public string NumConta { get; set; }
        public double Saldo { get; set; }

        public Conta() { } // para o serializer

        public Conta(string cliente, int agencia, string conta)
        {
            Cliente = cliente;
            Agencia = agencia;
            NumConta = conta;
        }

        public bool Depositar(double valorDeposito)
        {
            if (valorDeposito > 0)
            {
                Saldo += valorDeposito;
                return true;
            }

            return false;
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo >= valorSaque)
            {
                Saldo -= valorSaque;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Cliente + ", " + Agencia + ", " + NumConta + ", " + Saldo;
        }
    }
}
