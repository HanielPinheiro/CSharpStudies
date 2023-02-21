
using DesignPatterns.Descontos;
using DesignPatterns.Impostos;

namespace DesignPatterns.TemplateMethod
{
    public class IKCV : IImposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor > 500d && TemItemMaiorQueCemReais(orcamento))
                return orcamento.Valor * 0.1;

            return orcamento.Valor * 0.06;
        }

        private bool TemItemMaiorQueCemReais(Orcamento orcamento)
        {
            foreach (Item item in orcamento.itens)
                if(item.ValorItem() > 100)
                    return true;

            return false;
        }
    }
}
