using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Investimentos
{
    public class RealizadorInvestimentos
    {
        private const double taxaImpostoGoverno = 0.25;

        public void EfetuarInvestimento(Conta conta, Investimento investimento)
        {
            Console.WriteLine($"Saldo Atual: {conta.ConsultarSaldo()}");

            double saldo = conta.ConsultarSaldo();
            double retornoBrutoDoInvestimento = investimento.RetornoSobreInvestimento(saldo);

            double valorDesconto = retornoBrutoDoInvestimento * taxaImpostoGoverno;
            double retornoLiquidoDoInvestimento = retornoBrutoDoInvestimento - valorDesconto;
            
            Console.WriteLine($"Retorno Bruto do Investimento: {retornoBrutoDoInvestimento}");
            Console.WriteLine($"Desconto do Imposto: {valorDesconto}");
            Console.WriteLine($"Valor a receber: {retornoLiquidoDoInvestimento}");

            conta.Depositar(retornoLiquidoDoInvestimento);
            Console.WriteLine($"Saldo Atualizado: {conta.ConsultarSaldo()}");
            Console.WriteLine();
        }

    }
}
