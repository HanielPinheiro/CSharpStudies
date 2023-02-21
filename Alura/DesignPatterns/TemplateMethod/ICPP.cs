using DesignPatterns.Impostos;

namespace DesignPatterns.TemplateMethod
{
    public class ICPP : IImposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor >= 500d)
                return orcamento.Valor * 0.07;

            return orcamento.Valor * 0.05;
        }
    }
}
