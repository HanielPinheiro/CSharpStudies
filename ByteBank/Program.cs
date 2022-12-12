using ByteBank.Control;
using ByteBank.Holder;
using ByteBank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            Controler appControl = new Controler();
            try
            {
                appControl.StartApplication();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

       

        
    }
}

