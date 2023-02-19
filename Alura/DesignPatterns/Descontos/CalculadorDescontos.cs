using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Descontos
{
    public class CalculadorDescontos
    {
        private IDesconto descontos = null;
        private double valorDesconto = 0d;
        public CalculadorDescontos()
        {
            IDesconto d1 = new SemDesconto();
            IDesconto d2 = new DescontoCincoItens(d1);
            IDesconto d3 = new DescontoQuinhentosReais(d2);
            descontos = new DescontoVendaCasada(d3);
        }
        public double CalcularDesconto(Compra compra)
        {
            double valorDesconto = descontos.DescontoAplicado(compra);
            Console.WriteLine($"Desconto aplicado: {valorDesconto}");
            return valorDesconto;
        }
    }
}
