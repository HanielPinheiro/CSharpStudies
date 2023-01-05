using ByteBank.Control;
using ByteBank.Exceptions;
using ByteBank.Holder;
using ByteBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ByteBank.View
{
    public class ViewConsole
    {
        public char Option { get; private set; }
        public bool menuControl = true;

        private readonly Controler controler = new Controler();

        public void ShowData(CurrentAccount account)
        {
            Console.WriteLine($"Agencie: {account.SeeAgencie()}");
            Console.WriteLine($"Account: {account.SeeAccount()}");
            Console.WriteLine($"Holder: {account.holder.Id}");
            Console.WriteLine($"Balance: R$ {String.Format("{0:0.00}", account.SeeBalance())}");
            Console.WriteLine();
        }

        public void ShowBalance(CurrentAccount client)
        {
            Console.WriteLine($"Balance: R$ {String.Format("{0:0.00}", client.SeeBalance())}");
            Console.WriteLine();
        }


        public void ShowAccounts(List<CurrentAccount> accountsList)
        {
            Console.WriteLine("Accounts registereds:");
            for (int i = 0; i < accountsList.Count; i++)
            {
                CurrentAccount account = accountsList[i];
                Console.WriteLine($"{i} - {account.account} / {account.agencie_number}");
            }
            Console.WriteLine();
        }

        public void Menu()
        {
            try
            {
                while (menuControl)
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("===1 - Signin Account       ===");
                    Console.WriteLine("===2 - List  Accounts       ===");
                    Console.WriteLine("===3 - Remove Account       ===");
                    Console.WriteLine("===4 - Order Accounts       ===");
                    Console.WriteLine("===5 - Search Account       ===");
                    Console.WriteLine("===6 - Exit                 ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");

                    Console.Write("Choose the desired option: ");
                    try
                    {
                        Option = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {

                        throw new ByteBankException(excecao.Message);
                    }
                    

                    switch (Option)
                    {
                        case '1':
                            controler.SignIn();
                            break;
                        case '2':
                            controler.ListAccounts();
                            break;
                        case '3':
                            controler.RemoveAccount();
                            break;
                        case '4':
                            controler.OrderAccounts();
                            break;
                        case '5':
                            controler.SearchAccount();
                            break;
                        case '6':
                            menuControl = false;
                            break;
                        default:
                            Console.WriteLine("Invalid operation!");
                            break;
                    }
                }
            }
            catch(ByteBankException excecao)
            {
                Console.WriteLine($"{excecao.Message}"); ;
            }
        }


        
    }
}
