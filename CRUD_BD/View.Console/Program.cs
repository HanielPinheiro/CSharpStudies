using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using View.Console.Utils;

namespace View.Console
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //Orchestrator();
                MySerializer serializer = new MySerializer();
                serializer.Test();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static void Orchestrator()
        {
            Text text = new Text();
            Operation operation = new Operation();
            ConsoleKeyInfo choice;

            try
            {
                text.Welcome();
                text.ShowMenu();

                while (true)
                {
                    choice = System.Console.ReadKey();

                    if (choice.Key == ConsoleKey.C)
                        operation.Create();

                    //if (choice.Key == ConsoleKey.R)
                    //    operation.Retrieve();

                    //if (choice.Key == ConsoleKey.U)
                    //    operation.Update();

                    //if (choice.Key == ConsoleKey.D)
                    //    operation.Delete();

                    if (choice.Key == ConsoleKey.Q)
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
