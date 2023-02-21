using DesignPatterns.Descontos;
using System.Collections.Generic;

namespace DesignPatterns.Impostos
{
    public class Orcamento
    {
        public double Valor { get; private set; }

        public List<Item> itens = new List<Item>();

        public Orcamento(double valor )
        {
            this.Valor = valor;
        }
    }
}
