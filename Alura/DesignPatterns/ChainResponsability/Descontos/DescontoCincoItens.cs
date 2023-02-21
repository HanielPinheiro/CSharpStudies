using System;
using System.Collections.Generic;

namespace DesignPatterns.Descontos
{
    public class DescontoCincoItens : IDesconto
    {
        public IDesconto proximoDesconto { get; set; }

        public DescontoCincoItens(IDesconto proximoDesconto)
        {
            this.proximoDesconto = proximoDesconto;
        }

        public double DescontoAplicado(Compra compra)
        {
            foreach (KeyValuePair<Item, int> item in compra.Itens())
            {
                if (item.Value >= 5)
                {
                    Console.WriteLine("Compra de 5 ou mais itens iguais - 10% de desconto");
                    return 0.1 * compra.Total();
                }
            }

            return proximoDesconto.DescontoAplicado(compra);
        }

    }
}
