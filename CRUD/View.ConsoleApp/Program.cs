using DataManager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace View.ConsoleApp
{
    internal class Program
    {

        UsersDAO intermediate = new UsersDAO();
        

        void Main(string[] args)
        {
            bool control = true;

            Console.WriteLine("Programa iniciado! Para sair pressione 'S'");
            Console.WriteLine();

            while (control)
            {
                intermediate.List();

                Console.WriteLine("\nSelecione uma tecla da lista: C.R.U.D!");
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    default:
                        Console.WriteLine("Tecla inválida!");
                        break;
                    case ConsoleKey.C:
                        intermediate.CreateNew();
                        break;
                    case ConsoleKey.R:
                        intermediate.Read();
                        break;
                    case ConsoleKey.U:
                        intermediate.Update();
                        break;
                    case ConsoleKey.D:
                        intermediate.Delete();
                        break;
                    case ConsoleKey.S:
                        control = false;
                        break;
                }
            }
            Console.WriteLine("Encerrando programa!");
        }

       
    }
}