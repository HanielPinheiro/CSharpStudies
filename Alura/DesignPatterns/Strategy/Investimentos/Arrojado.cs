using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Investimentos
{
    public class Arrojado : Investimento
    {
        public double RetornoSobreInvestimento(double saldo)
        {
            int sorteio = new Random().Next(100) + 1;

            if (sorteio <= 20)
            {
                Console.WriteLine("Retorno = 5%");
                return 0.05 * saldo;
            }

            if (sorteio > 20 && sorteio <= 50)
            {
                Console.WriteLine("Retorno = 3%");
                return 0.03 * saldo;
            }

            Console.WriteLine("Retorno = 0,6%");
            return 0.006 * saldo;
        }
    }
}
