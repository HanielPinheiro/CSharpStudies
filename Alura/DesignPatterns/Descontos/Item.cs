using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Descontos
{
    public class Item
    {
        private string nome;
        private double valor;

        public Item(string nome, double valor)
        {
            this.nome = nome;
            this.valor = valor;
        }

        public string NomeItem()
        {
            return nome;
        }

        public double ValorItem()
        {
            return valor;
        }

    }
}
