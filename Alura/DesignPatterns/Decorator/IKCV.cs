using DesignPatterns.Descontos;
using DesignPatterns.Impostos;

namespace DesignPatterns.Decorator
{
    public class IKCV : TemplateDeImpostoCondicional
    {
        public IKCV(Imposto outroImposto) : base(outroImposto) { }
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500d && TemItemMaiorQueCemReais(orcamento);
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1 + CalculoDoOutroImposto(orcamento) ;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06 + CalculoDoOutroImposto(orcamento);
        }

        private bool TemItemMaiorQueCemReais(Orcamento orcamento)
        {
            foreach (Item item in orcamento.itens)
                if (item.ValorItem() > 100)
                    return true;

            return false;
        }
    }
}
