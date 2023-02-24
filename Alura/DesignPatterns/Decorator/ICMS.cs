using DesignPatterns.Impostos;

namespace DesignPatterns.Decorator
{
    public class ICMS : Imposto
    {
        public ICMS(Imposto outroImposto) : base(outroImposto) { }
        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1 + CalculoDoOutroImposto(orcamento) ;
        }
    }
}
