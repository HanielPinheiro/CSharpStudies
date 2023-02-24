using DesignPatterns.Impostos;

namespace DesignPatterns.Decorator
{
    public abstract class Imposto
    {
        public Imposto OutroImposto { get; private set; }

        public Imposto()
        {
            this.OutroImposto = null;
        }

        public Imposto(Imposto outroImposto)
        {
            OutroImposto = outroImposto;
        }

        public abstract double Calcular(Orcamento orcamento);

        protected double CalculoDoOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto == null) 
                return 0d;

            return OutroImposto.Calcular(orcamento);
        }
    }
}
