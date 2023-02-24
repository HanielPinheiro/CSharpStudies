using DesignPatterns.Impostos;
using System.Linq;

namespace DesignPatterns.Decorator
{
    public class IHIT : TemplateDeImpostoCondicional
    {
        public IHIT(Imposto outroImposto) : base(outroImposto) { }
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            foreach (var item in orcamento.itens)
                if (orcamento.itens.Where(p => p.NomeItem() == item.NomeItem()).Count() == 2)
                    return true;

            return false;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13 + 100d + CalculoDoOutroImposto(orcamento);
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.01 * orcamento.itens.Count() + CalculoDoOutroImposto(orcamento); ;
        }
    }
}
