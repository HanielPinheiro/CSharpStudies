using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Impostos
{
    public class CalculadorDeImpostos
    {
        public void RealizaCalculo(Orcamento orcamento, IImposto imposto)
        {
            Console.WriteLine($"Valor orçamento: - {orcamento.Valor} - {nameof(IImposto)}: {imposto.Calcular(orcamento)}" );
        }
    }
}
