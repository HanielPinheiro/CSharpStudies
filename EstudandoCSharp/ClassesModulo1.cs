using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Markup;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace Module1_CsharpUdemy_TextsAndCasting
{
    public class TextsAndCasting
    {
        private string product1 = "Computador";
        private string product2 = "Mesa de escritório";

        private byte age = 30;
        private int code = 5290;
        private char gender = 'M';

        private double price1 = 2100.0;
        private double price2 = 650.50;
        private double measure = 53.23456789;

        private double test1 = 5 / 2; //2 por causa da conversão implícita
        private double test2 = (double)5 / 2;// 2,5 por causa do 'casting'

        public void Run()
        {
            Console.WriteLine(test1 + " " + test2);
            Console.WriteLine("Produtos: \n{0}, cujo preço é $ {1} \n{2}, cujo preço é $ {3}", product1, price1.ToString("F2"), product2, price2.ToString("F2"));
            Console.WriteLine("\nRegistro: {0} anos de idade, código {1} e gênero: {2}", age, code, gender);
            Console.WriteLine("\nMedida com oito casas decimais: {0} \nArredondado (três casas decimais): {1} \nSeparador decimal invariant culture: {2}", measure.ToString("F8"), measure.ToString("F3"), measure.ToString("F3", CultureInfo.InvariantCulture));
        }
    }

    public class EntryData
    {
        private string name, lastName;
        private int? rooms, age;
        private double price, height;
        private string[] data;
        public void Run()
        {
            Console.WriteLine("Digite seu nome completo:");
            name = Console.ReadLine();
            Console.WriteLine("Quantos quartos tem na sua casa?");
            var temp = Console.ReadLine();
            if (temp?.Length > 0 && int.TryParse(temp, out int result)) rooms = result;
            Console.WriteLine("Digite com o preço de um produto:");
            temp = Console.ReadLine().ToString(CultureInfo.InvariantCulture); ;
            if (temp?.Length > 0 && double.TryParse(temp, out double result2)) price = result2;
            Console.WriteLine("Digite seu último nome, idade e alutra (mesma linha e separado por espaço):");
            temp = Console.ReadLine(); ;
            if (temp?.Length > 0) data = temp.Split(' ');
            if (data[0] != null) lastName = data[0];
            if (data[1] != null) age = int.Parse(data[1], CultureInfo.InvariantCulture);
            if (data[2] != null) height = double.Parse(data[2], CultureInfo.InvariantCulture);

            Console.WriteLine("\n\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}", name, rooms, price.ToString("f2", CultureInfo.InvariantCulture), lastName, age, height.ToString("F2", CultureInfo.InvariantCulture));

        }
    }

    public class SequentialStructure
    {
        public void exercise1()
        {
            int a = 0, b = 0, valor;

            Console.WriteLine("Digite a variável A:");
            var temp = Console.ReadLine().Replace(',', '.');
            if (temp?.Length > 0 && int.TryParse(temp, NumberStyles.Any, CultureInfo.InvariantCulture, out int result2)) a = result2;

            Console.WriteLine("Digite a variável B:");
            temp = Console.ReadLine().Replace(',', '.');
            if (temp?.Length > 0 && int.TryParse(temp, NumberStyles.Any, CultureInfo.InvariantCulture, out int result)) b = result;

            valor = a + b;

            Console.WriteLine($"SOMA = {valor}");
        }

        public void exercise2()
        {
            double area, raio = 0.00;

            Console.WriteLine("Digite o raio do círculo:");
            var temp = Console.ReadLine().Replace(',', '.');

            if (temp?.Length > 0 && double.TryParse(temp, NumberStyles.Any, CultureInfo.InvariantCulture, out double result)) raio = result;
            area = 3.14159 * Math.Pow(raio, 2);

            Console.WriteLine($"Area = {area.ToString("F4", CultureInfo.InvariantCulture)} m²");
        }

        public void exercise3()
        {
            int a, b, c, d;

            Console.WriteLine("Digite o valor de A:");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor de B:");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor de C:");
            c = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor de D:");
            d = int.Parse(Console.ReadLine());

            Console.WriteLine("DIFERENCA = {0}", (a * b - c * d));
        }

        public void exercise4()
        {
            int numberEmployee, workHours;
            double hourPrice;

            Console.WriteLine("Digite o código do funcionário:");
            numberEmployee = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número de horas trabalhadas:");
            workHours = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da hora");
            hourPrice = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);

            Console.WriteLine("\nNUMBER = {0}\nSALARY = U$ {1}", numberEmployee, (workHours * hourPrice).ToString("F2"));

        }

        public void exercise5()
        {
            Console.WriteLine("Digite os dados da primeira peça:");
            string[] peca1 = Console.ReadLine().Split(' ');

            Console.WriteLine("Digite os dados da primeira peça:");
            string[] peca2 = Console.ReadLine().Split(' ');

            if (peca1?.Length > 2 && peca2?.Length > 2)
            {
                double totalP1 = double.Parse(peca1[2].Replace(',', '.'), CultureInfo.InvariantCulture) * int.Parse(peca1[1]);
                double totalP2 = double.Parse(peca2[2].Replace(',', '.'), CultureInfo.InvariantCulture) * int.Parse(peca2[1]);
                Console.WriteLine("VALOR A PAGAR: R$ {0}", (totalP1 + totalP2).ToString("F2"));
            }
        }

        public void exercise6()
        {
            double triangleArea(double b, double h) { return ((b * h) / 2.0); };
            double circleArea(double r) { return (3.14159 * Math.Pow(r, 2)); };
            double trapeziumArea(double b1, double b2, double h) { return (((b1 + b2) * h) / 2.0); };
            double squareArea(double a) { return (Math.Pow(a, 2)); };
            double rectangleArea(double a, double b) { return (a * b); };

            Console.WriteLine("Digite os dados:");
            string[] values = Console.ReadLine().Split(' ');
            if (values?.Length > 0)
            {
                try
                {
                    double a = double.Parse(values[0].Replace(',', '.'), CultureInfo.InvariantCulture);
                    double b = double.Parse(values[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                    double c = double.Parse(values[2].Replace(',', '.'), CultureInfo.InvariantCulture);

                    Console.WriteLine("TRIANGULO: {0}", triangleArea(a, c).ToString("F3"));
                    Console.WriteLine("CIRCULO: {0}", circleArea(c).ToString("F3"));
                    Console.WriteLine("TRAPEZIO: {0}", trapeziumArea(a, b, c).ToString("F3"));
                    Console.WriteLine("QUADRADO: {0}", squareArea(b).ToString("F3"));
                    Console.WriteLine("RETANGULO: {0}", rectangleArea(a, b).ToString("F3"));

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
                Console.WriteLine("Entrada inválida!");
        }
    }

    public class ConditionalStructure
    {
        private Tuple<int, int> maximo(int a, int b)
        {
            int major, minor;

            if (a > b) { major = a; minor = b; } else { major = b; minor = a; };

            return Tuple.Create(major, minor);
        }

        public void exercise3()
        {
            Console.WriteLine("Digite o valor de A:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor de B:");
            int b = int.Parse(Console.ReadLine());

            int major = maximo(a, b).Item1;
            int minor = maximo(a, b).Item2;

            if (major % minor == 0)
                Console.WriteLine("SÃO MÚLTIPLOS");
            else
                Console.WriteLine("NÃO SÃO MÚLTIPLOS");
        }

        public void exercise4()
        {
            Console.WriteLine("Digite a hora de início e fim do jogo separado por ' ':");
            string[] hora = Console.ReadLine().Split(' ');
            int start = 0, end = 0;
            bool valid = true;

            while (valid)
            {
                if (hora.Length == 2 && int.TryParse(hora[0], out start) && int.TryParse(hora[1], out end))
                {
                    valid = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Digite a hora de início e fim do jogo separado por ' ':");
                    hora = Console.ReadLine().Split(' ');

                }
            }
            if (start < end) Console.WriteLine("O JOGO DUROU 24 HORAS");
            else Console.WriteLine("O JOGO DUROU {0} HORAS", (24 - start + end));

        }

        public void exercise5()
        {
            Console.WriteLine("Digite o código e a quantidade separados por ' ':");
            string[] dados = Console.ReadLine().Split(' ');
            int codigo = 0, qtde = 0;
            bool valid = true;

            while (valid)
            {
                if (dados.Length == 2 && int.TryParse(dados[0], out codigo) && int.TryParse(dados[1], out qtde))
                {
                    valid = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Digite o código e a quantidade separados por ' ':");
                    dados = Console.ReadLine().Split(' ');
                }
            }

            switch (codigo)
            {
                default:
                    Console.WriteLine("Entrada inválida");
                    break;
                case 1:
                    Console.WriteLine("Total: R$ {0}", (4.0 * qtde).ToString("F2", CultureInfo.InvariantCulture));
                    break;
                case 2:
                    Console.WriteLine("Total: R$ {0}", (4.5 * qtde).ToString("F2", CultureInfo.InvariantCulture));
                    break;
                case 3:
                    Console.WriteLine("Total: R$ {0}", (5.0 * qtde).ToString("F2", CultureInfo.InvariantCulture));
                    break;
                case 4:
                    Console.WriteLine("Total: R$ {0}", (2.0 * qtde).ToString("F2", CultureInfo.InvariantCulture));
                    break;
                case 5:
                    Console.WriteLine("Total: R$ {0}", (1.5 * qtde).ToString("F2", CultureInfo.InvariantCulture));
                    break;
            }


        }

        public void exercise7()
        {
            string msg = "Digite a coordenada x e y, respectivament, separados por ' ':";
            Console.WriteLine(msg);

            string read = Console.ReadLine();
            string[] coord = read.Split(' ');
            double x = 0.0, y = 0.0;
            bool valid = true;
            while (valid)
            {
                if (coord.Length == 2 && double.TryParse(coord[0], out x) && double.TryParse(coord[1], out y))
                {
                    valid = false;
                    break;
                }
                else
                {
                    Console.WriteLine(msg);
                    coord = Console.ReadLine().Split(' ');

                }
            }

            if (x > 0.0 && y > 0.0) Console.WriteLine("Q1");
            else if (x < 0.0 && y > 0.0) Console.WriteLine("Q2");
            else if (x < 0.0 && y < 0.0) Console.WriteLine("Q3");
            else if (x > 0.0 && y < 0.0) Console.WriteLine("Q4");
            else if (x == 0.0 && y == 0.0) Console.WriteLine("Origem");
            else if (x == 0.0) Console.WriteLine("Eixo Y");
            else if (y == 0.0) Console.WriteLine("Eixo X");
        }
        public void exercise8()
        {
            string msg = "Digite seu salário:";
            Console.WriteLine(msg);
            string dado = Console.ReadLine();
            double salario = 0.0f;
            bool valid = true;

            while (valid)
            {
                if (double.TryParse(dado.Replace(',','.'), NumberStyles.Any, CultureInfo.InvariantCulture, out salario))
                {
                    valid = false;
                    break;
                }
                else
                {
                    Console.WriteLine(msg);
                    dado = Console.ReadLine();

                }
            }

            salario = Math.Round(salario, 2);

            if (salario >= 0.00 && salario <= 2000.00) Console.WriteLine("Isento");
            else if(salario >= 2000.01)
            {

            }
        }
    }
}

