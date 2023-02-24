using DesignPatterns.Impostos;
using System;

namespace DesignPatterns.Decorator
{
    public class ICCC : Imposto
    {
        public ICCC(Imposto outroImposto) : base(outroImposto) { }

        public override double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000d)
                return orcamento.Valor * 0.05 + CalculoDoOutroImposto(orcamento); 

            if (orcamento.Valor >= 1000d && orcamento.Valor <=3000d)
                return orcamento.Valor * 0.07  + CalculoDoOutroImposto(orcamento); 

            if (orcamento.Valor > 3000d)
                return orcamento.Valor * 0.08 + 30d + CalculoDoOutroImposto(orcamento); 

            throw new ArgumentException($"Invalid argument {orcamento}");
        }
    }
}
