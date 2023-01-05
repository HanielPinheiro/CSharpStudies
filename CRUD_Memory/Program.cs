using ByteBank.Holder;
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

            try
            {
                Execute();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Execute()
        {
            Client andre = new Client("André", "388012745 60", "11912344456");
            Client maria = new Client("Maria", "005442732-0X", "11912344456");

            CurrentAccount andreAccount = new CurrentAccount(15, "1010-X", andre, 100);
            CurrentAccount mariaAccount = new CurrentAccount(17, "1010-5", maria, 350);

            ShowData(andreAccount);
            ShowBalance(mariaAccount);
        }

        static void ShowData(CurrentAccount account)
        {
            Console.WriteLine($"Agencie: {account.SeeAgencie()}");
            Console.WriteLine($"Account: {account.SeeAccount()}");
            Console.WriteLine($"Holder: {account.SeeHolder()[0]}");
            Console.WriteLine($"Balance: R$ {String.Format("{0:0.00}", account.SeeBalance())}");
            Console.WriteLine();
        }

        static void ShowBalance(CurrentAccount client)
        {
            Console.WriteLine($"Balance: R$ {String.Format("{0:0.00}", client.SeeBalance())}");
            Console.WriteLine();
        }
    }
}

