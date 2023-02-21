using DesignPatterns.Investimentos;
using System;

namespace DesignPatterns.Descontos
{
    public class DescontoQuinhentosReais : IDesconto
    {
        public IDesconto proximoDesconto { get; set; }

        public DescontoQuinhentosReais(IDesconto proximoDesconto)
        {
            this.proximoDesconto = proximoDesconto;
        }

        public double DescontoAplicado(Compra compra)
        {
            if (compra.Total() >= 500d)
            {
                Console.WriteLine("Venda superior a Quinhentos Reais - 5% de desconto");
                return 0.05 * compra.Total();
            }

            return proximoDesconto.DescontoAplicado(compra);
        }
    }
}
