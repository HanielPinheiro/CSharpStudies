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

namespace View.ConsoleApp
{
    internal static class Program
    {
        private static CrudManager manager = new CrudManager();

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Program started! Press 'Esc' to exit");
            Console.WriteLine();
            Run();
        }

        public static void Run()
        {
            bool control = true;            

            Console.WriteLine("\nHello, welcome to the Contacts Manger, you have 0 contacts registered.");
            Console.WriteLine("\nYou can register until " + (BusinessDataValidation.availableContacts - manager.GetCount()) + " contacts. ");;

            while (control)
            {
                manager.ListData();
               
                Console.WriteLine("\n\nSelect one key of list: C.R.U.D - 'Esc' to exit\n");
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
                    case ConsoleKey.Escape:
                        control = false;
                        break;
                }
            }
            Console.WriteLine("\nClosing program!");
        }

    }
}