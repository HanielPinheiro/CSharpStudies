using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Impostos
{
    public class ICCC : IImposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000d)
                return orcamento.Valor * 0.05;

            if (orcamento.Valor >= 1000d && orcamento.Valor <=3000d)
                return orcamento.Valor * 0.07;

            if (orcamento.Valor > 3000d)
                return orcamento.Valor * 0.08 + 30d;

            throw new ArgumentException($"Invalid argument {orcamento}");
        }
    }
}
