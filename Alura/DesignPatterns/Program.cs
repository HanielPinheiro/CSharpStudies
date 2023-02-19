using DesignPatterns.Descontos;
using DesignPatterns.Impostos;
using DesignPatterns.Investimentos;
using System;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Impostos(); 
            //Investimentos(); 
            Descontos();
            Console.ReadKey();
        }

        #region Strategy

        private static void Impostos()
        {
            IImposto iccc = new ICCC();

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            Orcamento orcamento = new Orcamento(600d);
            Orcamento orcamento2 = new Orcamento(1500d);
            Orcamento orcamento3 = new Orcamento(20000d);

            calculador.RealizaCalculo(orcamento, iccc);
            calculador.RealizaCalculo(orcamento2, iccc);
            calculador.RealizaCalculo(orcamento3, iccc);
        }

        private static void Investimentos()
        {
            Investimento conservador = new Conservador();
            Investimento moderado = new Moderado();
            Investimento arrojado = new Arrojado();

            Conta conta = new Conta("sujeito", 000, "1234-X");
            conta.Depositar(1000d);

            RealizadorInvestimentos realizadorInvestimentos = new RealizadorInvestimentos();

            Console.WriteLine("Conservador:");
            realizadorInvestimentos.EfetuarInvestimento(conta, conservador);

            Console.WriteLine("Moderado:");
            realizadorInvestimentos.EfetuarInvestimento(conta, moderado);

            Console.WriteLine("Arrojado:");
            realizadorInvestimentos.EfetuarInvestimento(conta, arrojado);
        }

        #endregion

        #region ChainOfResponsability

        private static void Descontos()
        {
            Compra compra = new Compra();


            //Item teste = new Item("teste", 5d); //Caso dos dois descontos com pobrema perguntar mano Carlos
            //compra.AdicionarItem(teste, 100);

            //Item teste2 = new Item("teste", 5d); //Caso Mais 5 Itens
            //compra.AdicionarItem(teste2, 10);

            //Item teste3 = new Item("teste", 5000d); //Caso Mais 500 reais
            //compra.AdicionarItem(teste3, 1);

            //Item teste4 = new Item("teste", 5d); //Caso sem Desconto
            //compra.AdicionarItem(teste4, 1);

            Item teste5 = new Item("lapis", 5d); //Caso venda casada
            Item teste6 = new Item("caneta", 5d);
            compra.AdicionarItem(teste5, 2);
            compra.AdicionarItem(teste6, 2);


            Console.WriteLine($"Total sem Desconto = {compra.Total()}");
            
            CalculadorDescontos calculador = new CalculadorDescontos();
            var desconto = calculador.CalcularDesconto(compra);
            compra.AplicaDesconto(desconto);
            
            Console.WriteLine($"Total com Desconto = {compra.Total()}");
        }

        #endregion

    }
}


