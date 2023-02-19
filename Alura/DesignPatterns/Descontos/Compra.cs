using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Descontos
{
    public class Compra
    {
        private Dictionary<Item, int> items = new Dictionary<Item, int>();
        private double total = 0d;

        public void AdicionarItem(Item item, int quantidade)
        {
            items.Add(item, quantidade);
            CalculaTotal();
        }

        private void CalculaTotal()
        {
            foreach (KeyValuePair<Item, int> item in items)
            {
                var qtde = item.Value;
                var valorItem = item.Key.ValorItem();
                this.total += qtde * valorItem;
            }
        }

        public Dictionary<Item, int> Itens()
        {
            return items;
        }

        public double Total()
        {
            return total;
        }

        public void AplicaDesconto(double valor)
        {
            this.total -= valor;
        }

    }
}
