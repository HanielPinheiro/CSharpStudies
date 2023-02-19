using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Investimentos
{
    public class Conservador : Investimento
    {
        public double RetornoSobreInvestimento(double saldo)
        {
            Console.WriteLine("Retorno = 80%");
            return 0.8 * saldo;
        }
    }
}
