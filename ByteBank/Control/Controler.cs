using ByteBank.Employer;
using ByteBank.Holder;
using ByteBank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Control
{
    public class Controler
    {
        private ViewWinForms winFormsApp = new ViewWinForms();
        private ViewConsole consoleApp = new ViewConsole();
        private readonly int controlType = 0;

        public static readonly List<CurrentAccount> accounts = new List<CurrentAccount>();
        public static readonly List<Client> clients = new List<Client>();

        public static readonly List<Employers> employers = new List<Employers>();
        public static readonly List<Director> directors = new List<Director>();

        public Controler(string model)
        {
            if (model == "Console")
                controlType = 1;

            if (model == "Form")
                controlType = 2;
        }

        public void StartApplication()
        {
            InitializeData();

            if (controlType == 1)
                ActionsFlux();

            if (controlType == 2)
                winFormsApp.Show();
        }

        public void InitializeData()
        {
            StartClientsAndAccounts();
            //StartEmployers(5);
        }

        public void ActionsFlux()
        {
            consoleApp.ShowData(accounts.FirstOrDefault(p => p.holder.name == "André"));
            consoleApp.ShowBalance(accounts.FirstOrDefault(p => p.holder.name == "Maria"));
        }

        public void StartClientsAndAccounts()
        {
            Client andre = new Client("André", "38801274560", "11912344456");
            clients.Add(andre);
            Client maria = new Client("Maria", "005442732-0X", "11985456727");
            clients.Add(maria);

            CurrentAccount mariaAccount = new CurrentAccount(17, "1010-5", maria, 350);
            accounts.Add(mariaAccount);
            CurrentAccount andreAccount = new CurrentAccount(12, "0834-X", andre, 1050);
            accounts.Add(andreAccount);
        }

    }
}
