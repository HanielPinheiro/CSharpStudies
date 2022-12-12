using ByteBank.Employer;
using ByteBank.Holder;
using ByteBank.InternalSystem;
using ByteBank.Partner;
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

        private readonly List<CurrentAccount> accounts;
        private readonly List<Client> clients;

        private readonly List<Employers> employers = new List<Employers>();
        private readonly List<Director> directors = new List<Director>();
        private readonly List<ComercialPartner> comercialPartners = new List<ComercialPartner>();

        private readonly SystemManager systemManager;

        public Controler()
        {
            controlType = 1; // console
            // controlType = 2; // winforms

            accounts = new List<CurrentAccount>();
            clients = new List<Client>();

            employers = new List<Employers>();
            directors = new List<Director>();
            comercialPartners = new List<ComercialPartner>();
            systemManager  = new SystemManager();
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
            StartEmployers();
            StartParners();
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

        public void StartEmployers()
        {
            Director joana = new Director("98564231568", 40000);
            joana.Name = "Joana das Neves";
            joana.Password = "783";
            employers.Add(joana);

            Console.WriteLine($"Trying login {nameof(joana)}");
            systemManager.Login(joana, "825");

            Manager pedro = new Manager("58564231596", 10000);
            pedro.Name = "Pedro Stark";
            pedro.Password = "555";
            employers.Add(pedro);

            Console.WriteLine($"Trying login {nameof(pedro)}");
            systemManager.Login(pedro, "555");

            Analist jhon = new Analist("03354698677", 10000);
            jhon.Name = "João das Neves";
            employers.Add(jhon);

            Programmer lara = new Programmer("77741235162", 10000);
            lara.Name = "Lara Vel";
            employers.Add(lara);

            Programmer emir = new Programmer("07842156385", 10000);
            emir.Name = "Emir Ados";
            employers.Add(emir);
        }

        public void StartParners()
        {
            ComercialPartner caio = new ComercialPartner();
            caio.Password = "333";
            comercialPartners.Add(caio);

            Console.WriteLine($"Trying login {nameof(caio)}");
            systemManager.Login(caio, "333");
        }

    }
}
