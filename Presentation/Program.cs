using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class Program
    {
        private static UserManager userManager = new UserManager();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Digite o ID");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o nome do user");
                string name = Console.ReadLine();

                Console.WriteLine("Digite a idade");
                int idade = Convert.ToInt32(Console.ReadLine());

                User user = new User();
                user.Id = id;
                user.Name = name;
                user.Age = idade;

                Console.WriteLine("Qual operação deseja fazer?");
                Console.WriteLine("C.R.U.D");
                Console.WriteLine("");

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.C:
                        userManager.Create(user);
                        break;

                    case ConsoleKey.R:
                        userManager.Retrieve(user.Id);
                        break;

                    case ConsoleKey.U:
                        userManager.Update(user.Id, user);
                        break;

                    case ConsoleKey.D:
                        userManager.Delete(user.Id);
                        break;

                    default:
                        Console.WriteLine("Seu jão");
                        break;

                }
            }
        }
    }
}
