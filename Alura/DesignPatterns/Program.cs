using DesignPatterns.Decorator;
using DesignPatterns.Descontos;
using DesignPatterns.FormatosExportar;
using DesignPatterns.Impostos;
using DesignPatterns.Interfaces;
using DesignPatterns.Investimentos;
using DesignPatterns.TemplateMethod.Imposto;
using DesignPatterns.TemplateMethod.Relatorios;
using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Impostos(); 
            //Investimentos(); 

            //Descontos();
            //RequisicaoNoFormatoDesejado();

            //TemplateImpostos();
            //GerandoRelatorios();

            DecorandoImpostos();

            Console.ReadKey();
        }

        #region Strategy

        private static void Impostos()
        {
            IImposto iccc = new Impostos.ICCC();

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


        private static void RequisicaoNoFormatoDesejado()
        {
            Conta conta = new Conta("Haniescreiçon", 25, "5575-X");
            conta.Depositar(1000000d);

            IFormato xml = new XML(null);
            IFormato porcento = new PORCENTO(xml);
            IFormato csv = new CSV(porcento);

            string requisicao = csv.Requisicao(conta, Formato.XML);
            Console.WriteLine(requisicao);
        }

        #endregion

        #region TemplateMethod

        public static void TemplateImpostos()
        {
            IImposto ikcv = new TemplateMethod.Imposto.IKCV();
            IImposto icpp = new TemplateMethod.Imposto.ICPP();

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            Orcamento orcamento = new Orcamento(600d);
            Orcamento orcamento2 = new Orcamento(1500d);

            calculador.RealizaCalculo(orcamento, ikcv);
            calculador.RealizaCalculo(orcamento2, icpp);
        }

        public static void GerandoRelatorios()
        {
            Banco banco = new Banco("NewBank", "11 2222-3030", "Rua dos bobos, numero 0", "nuncaAtendem@newbank.com.br");

            List<Conta> contas = new List<Conta>
            {
                new Conta("Jose", 1, "0001"),
                new Conta("Joao", 2, "0002")
            };

            var relatorioSimples = new RelatorioSimples();
            var relatorioComplexo = new RelatorioComplexo();

            relatorioSimples.ImprimeRelatorio(banco, contas);
            relatorioComplexo.ImprimeRelatorio(banco, contas);
        }

        #endregion

        #region Decorator
        public static void DecorandoImpostos()
        {
            Imposto iss = new Decorator.ISS( new Decorator.ICMS( new IMA(null) ) );

            Orcamento orcamento = new Orcamento(500);

            double valor = iss.Calcular(orcamento);

            Console.WriteLine(valor);
        }
        #endregion
    }
}


