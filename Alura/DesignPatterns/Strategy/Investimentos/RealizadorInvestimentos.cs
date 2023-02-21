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
            Console.WriteLine($"Saldo Atual: {conta.Saldo}");

            double saldo = conta.Saldo;
            double retornoBrutoDoInvestimento = investimento.RetornoSobreInvestimento(saldo);

            double valorDesconto = retornoBrutoDoInvestimento * taxaImpostoGoverno;
            double retornoLiquidoDoInvestimento = retornoBrutoDoInvestimento - valorDesconto;
            
            Console.WriteLine($"Retorno Bruto do Investimento: {retornoBrutoDoInvestimento}");
            Console.WriteLine($"Desconto do Imposto: {valorDesconto}");
            Console.WriteLine($"Valor a receber: {retornoLiquidoDoInvestimento}");

            conta.Depositar(retornoLiquidoDoInvestimento);
            Console.WriteLine($"Saldo Atualizado: {conta.Saldo}");
            Console.WriteLine();
        }

    }
}
