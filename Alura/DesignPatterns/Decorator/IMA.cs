using DesignPatterns.Impostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class IMA : Imposto
    {
        public IMA(Imposto outroImposto) : base(outroImposto) { }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.2 + CalculoDoOutroImposto(orcamento);
        }
    }
}
