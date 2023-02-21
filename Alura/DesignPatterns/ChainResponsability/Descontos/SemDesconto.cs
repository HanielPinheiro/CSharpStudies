using DesignPatterns.Investimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Descontos
{
    public class SemDesconto : IDesconto
    {
        public IDesconto proximoDesconto { get; set; }

        public double DescontoAplicado(Compra compra)
        {
            Console.WriteLine("Nenhum desconto se aplica");
            return 0d;
        }
    }
}
