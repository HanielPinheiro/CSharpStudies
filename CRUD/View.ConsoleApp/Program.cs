using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;

namespace View.ConsoleApp
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Program started! Pres 'S' to exit");
            Console.WriteLine();
            Run();
        }

        public static void Run()
        {
            bool control = true;
            CrudManager manager = new CrudManager();

            while (control)
            {
                manager.ListData();

                Console.WriteLine("\nSelect one key of list: C.R.U.D!");
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    default:
                        Console.WriteLine("\nInvalid Console key!");
                        break;
                    case ConsoleKey.C:
                        manager.Create();
                        break;
                    case ConsoleKey.R:
                        manager.Read();
                        break;
                    case ConsoleKey.U:
                        manager.Update();
                        break;
                    case ConsoleKey.D:
                        manager.Delete();
                        break;
                    case ConsoleKey.S:
                        control = false;
                        break;
                }
            }
            Console.WriteLine("\nClosing program!");
        }

    }
}