
using DesignPatterns.Descontos;
using DesignPatterns.Impostos;

namespace DesignPatterns.TemplateMethod.Imposto
{
    public class IKCV : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500d && TemItemMaiorQueCemReais(orcamento);
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
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
