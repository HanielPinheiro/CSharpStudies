using ByteBank.Holder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.View
{
    public class ViewConsole
    {
        
        public void ShowData(CurrentAccount account)
        {
            Console.WriteLine($"Agencie: {account.SeeAgencie()}");
            Console.WriteLine($"Account: {account.SeeAccount()}");
            Console.WriteLine($"Holder: {account.SeeHolder()[0]}");
            Console.WriteLine($"Balance: R$ {String.Format("{0:0.00}", account.SeeBalance())}");
            Console.WriteLine();
        }

        public void ShowBalance(CurrentAccount client)
        {
            Console.WriteLine($"Balance: R$ {String.Format("{0:0.00}", client.SeeBalance())}");
            Console.WriteLine();
        }
    }
}
