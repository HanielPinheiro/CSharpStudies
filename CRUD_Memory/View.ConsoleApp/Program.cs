using System;

namespace View.ConsoleApp
{
    internal static class Program
    {
        private static Operations operationManager = new Operations();
        
        
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
                operationManager.ListData();

                Console.WriteLine("\nSelect one key of list: C.R.U.D - 'Q' to Quit");
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.C:
                        operationManager.Create();
                        break;
                    case ConsoleKey.R:
                        operationManager.Retrieve();
                        break;
                    case ConsoleKey.U:
                        operationManager.Update();
                        break;
                    case ConsoleKey.D:
                        operationManager.Delete();
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