using ByteBank.Employer;
using ByteBank.Exceptions;
using ByteBank.Holder;
using ByteBank.InternalSystem;
using ByteBank.Partner;
using ByteBank.Util;
using ByteBank.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ByteBank.Control
{
    public class Controler
    {
        private readonly int controlType = 0;

        private readonly CurrentAccountsArray accountsList;
        private readonly List<Client> clients;

        private readonly List<Employers> employers = new List<Employers>();
        private readonly List<Director> directors = new List<Director>();
        private readonly List<ComercialPartner> comercialPartners = new List<ComercialPartner>();

        private readonly SystemManager systemManager;

        public Controler()
        {
            controlType = 1; // console
            // controlType = 2; // winforms

            accountsList = new CurrentAccountsArray();
            clients = new List<Client>();

            employers = new List<Employers>();
            directors = new List<Director>();
            comercialPartners = new List<ComercialPartner>();
            systemManager = new SystemManager();
        }

        public void StartApplication()
        {
            InitializeData();
            ViewConsole view = new ViewConsole();
            view.Menu();
        }

        public void InitializeData()
        {
            StartClientsAndAccounts();
            StartEmployers();
            StartParners();
        }

        public void ActionsFlux()
        {
            //consoleApp.ShowData(clients.FirstOrDefault(p => p.Name == "André"));
            //consoleApp.ShowBalance(clients.FirstOrDefault(p => p.Name == "Maria"));
        }

        public void StartClientsAndAccounts()
        {
            Client andre = new Client("André", "38801274560", "11912344456");
            clients.Add(andre);
            Client maria = new Client("Maria", "0054427320X", "12123321");
            clients.Add(maria);
            Client marcus = new Client("Marcus", "76645573201", "123312");
            clients.Add(marcus);
            Client sara = new Client("Sara", "02344273240", "213123123123");
            clients.Add(sara);
            Client ligia = new Client("Ligia", "824542342-0X", "12312312312");
            clients.Add(ligia);
            Client jhon = new Client("Jhon", "005443872-0X", "123123123");
            clients.Add(jhon);

            accountsList.Add(new CurrentAccount(17, "1010-5", maria, 350));
            accountsList.Add(new CurrentAccount(12, "0834-X", andre, 1050));
            accountsList.Add(new CurrentAccount(11, "0834-X", marcus, 00));
            accountsList.Add(new CurrentAccount(8, "0774-X", sara, 100));
            accountsList.Add(new CurrentAccount(4, "6545-X", ligia, 250));
            accountsList.Add(new CurrentAccount(36, "3727-X", jhon, 10000));

            //Console.WriteLine($"Holder with more money in the bank: {accountsList.HigherBalance().holder.Name}\n");
            //Console.WriteLine(accountsList.ToString());
            //accountsList.Remove(accountsList.HigherBalance());
            //Console.WriteLine($"Holder with more money in the bank: {accountsList.HigherBalance().holder.Name}\n");
            //Console.WriteLine(accountsList.ToString());

            //consoleApp.ShowAccounts(accountsList);
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

        #region ConsoleApp MenuControl

        public void SignIn()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===        ASSIGN  IN       ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");

            Console.Write("Número da conta: ");
            string numeroConta = Console.ReadLine();

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());                      

            Console.Write("Insert the balance of account: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Insert the name of holder: ");
            string name = Console.ReadLine();

            Console.Write("Insert the CPF of holder: ");
            string cpf = Console.ReadLine();

            Console.Write("Insert the phone of holder: ");
            string phone = Console.ReadLine();

            Client newClient = new Client(name, cpf, phone);
            CurrentAccount conta = new CurrentAccount(numeroAgencia, numeroConta, newClient, balance);

            accountsList.Add(conta);
            Console.WriteLine("... Account assigned successfully! ...");
            Console.ReadKey();
        }

        public void ListAccounts()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      ACCOUNTS LIST      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            if (accountsList.Count() <= 0)
            {
                Console.WriteLine("... Don`t have anyone assigned! ...");
                Console.ReadKey();
                return ;// exit  of the method
            }
            foreach (CurrentAccount item in accountsList)
            {
                Console.WriteLine("===     Account data    ===");
                //Console.WriteLine("Number : " + item.account);
                //Console.WriteLine("Balance: " + item.SeeBalance());
                //Console.WriteLine("Holder: " + item.holder.Name);
                //Console.WriteLine("Holder CPF: " + item.holder.Cpf);
                //Console.WriteLine("Profissão do Titular: " + item.holder.Phone);
                accountsList.ToString();
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
            }
        }

        public void RemoveAccount()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     REMOVE  ACCOUNTS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Insert the account number: ");

            string accountNumber = Console.ReadLine();

            try
            {
                if (accountsList.Remove(accountNumber))
                {
                    Console.WriteLine("Removed succesfully");
                    OrderAccounts();
                }
                else
                {
                    throw new ByteBankException("Fail when try to remove this account");
                }
            }
            catch(ByteBankException ex)
            {
                throw new ByteBankException("Error: "+ex.Message);
            }
            
        }

        public void OrderAccounts()
        {
            accountsList.Sort();
            Console.WriteLine("... Count list ordered ...");
            Console.ReadKey();
        }
        public void SearchAccount()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    SEARCH  ACCOUNTS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Do you want to search by the (1) ACCOUNT NUMBER or (2) HOLDER CPF ? ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Insert the account number: ");
                        string accountNumber = Console.ReadLine();
                        CurrentAccount accountConsulted = SearchByAccountNumber(accountNumber);
                        Console.WriteLine(accountConsulted.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o CPF do Titular: ");
                        string cpf = Console.ReadLine();
                        CurrentAccount consultaCpf = SearchByHolderCPF(cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }

        CurrentAccount SearchByHolderCPF(string cpf)
        {
            CurrentAccount conta = null;
            for (int i = 0; i < accountsList.Count(); i++)
            {
                if (accountsList[i].holder.Cpf.Equals(cpf))
                {
                    conta = accountsList[i];
                }
            }
            return conta;
        }

        CurrentAccount SearchByAccountNumber(string numeroConta)
        {
            CurrentAccount conta = null;
            for (int i = 0; i < accountsList.Count(); i++)
            {
                if (accountsList[i].account.Equals(numeroConta))
                {
                    conta = accountsList[i];
                }
            }

            return conta;
        }

        #endregion

        //private List<CurrentAccount> ConsultaPorAgencia(int numeroAgencia)
        //{
        //    var consulta = (
        //                         from conta in accountsList
        //                         where conta.Numero_agencia == numeroAgencia
        //                         select conta).ToList();
        //    return consulta;
        //}
    }
}
