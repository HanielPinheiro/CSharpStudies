using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Descontos
{
    public class DescontoVendaCasada : IDesconto
    {
        public IDesconto proximoDesconto { get; set; }

        public DescontoVendaCasada(IDesconto proximoDesconto)
        {
            this.proximoDesconto = proximoDesconto;
        }

        public double DescontoAplicado(Compra compra)
        {
            if (ExisteVendaCasada(compra))
            {
                Console.WriteLine("Existe Venda Casada - 5% de desconto");
                return compra.Total() * 0.05;
            }
            return proximoDesconto.DescontoAplicado(compra);
        }

        public bool ExisteVendaCasada(Compra compra)
        {
            bool lapis = false;
            bool caneta = false;

            foreach (var item in compra.Itens())
            {
                if (item.Key.NomeItem().ToLower() == nameof(lapis).ToLower())
                    lapis = true;

                if (item.Key.NomeItem().ToLower() == nameof(caneta).ToLower())
                    caneta = true;
            }

            if (lapis && caneta)
                return true;

            return false;
        }
    }
}
