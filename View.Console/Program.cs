using System;

namespace View.Console
{
    public class Program
    {
        //private static Operation operation = new Operation();
        private static Text text = new Text();

        private static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static void Run()
        {
            try
            {
                text.Welcome();
                text.ShowMenu();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
