using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Investimentos
{
    public class Moderado : Investimento
    {
        public double RetornoSobreInvestimento(double saldo)
        {
            int sorteio = new Random().Next(100) + 1;

            if (sorteio >= 50)
            {
                Console.WriteLine("Retorno = 0,7%");
                return 0.007 * saldo;
            }

            Console.WriteLine("Retorno = 2,5%");
            return 0.025 * saldo;
        }
    }
}
