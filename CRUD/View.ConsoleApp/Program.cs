using Microsoft.Win32;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;
using Model;

namespace View.ConsoleApp
{
    internal static class Program
    {
        private static Manager manager = new Manager();

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Program started! Press 'Esc' to exit");
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void Run()
        {
            bool control = true;

            while (control)
            {
                manager.ListData();

                Console.WriteLine("\nSelect one key of list: C.R.U.D - 'Q' to Quit");
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.C:
                        manager.Create();
                        break;
                    case ConsoleKey.R:
                        manager.Retrieve();
                        break;
                    case ConsoleKey.U:
                        manager.Update();
                        break;
                    case ConsoleKey.D:
                        manager.Delete();
                        break;
                    case ConsoleKey.Q:
                        control = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Console key!");
                        break;
                }
            }
            Console.WriteLine("\nClosing program!");
        }
    }
}