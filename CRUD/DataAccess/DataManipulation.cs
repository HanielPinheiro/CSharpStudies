using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataManipulation
    {
        

        void CreateNew(List<User> listUsers)
        {
            
        }

        void Read()
        {
            int idUser;
            while (true)
            {
                Console.WriteLine("\nDigite o id do usuário a ser lido:");
                if (int.TryParse(Console.ReadLine(), out idUser) && users.Contains(users[idUser]))
                    break;
            }

            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}", users[idUser].Id, users[idUser].Name, users[idUser].LastName,
                users[idUser].Age, users[idUser].Email, users[idUser].Tel, users[idUser].Country);

        }

        void Update()
        {
            int idUser;
            while (true)
            {
                Console.WriteLine("\nDigite o id do usuário a ser alterado:");
                if (int.TryParse(Console.ReadLine(), out idUser))
                    break;
            }

            User newUser = new User();
            newUser.Id = idUser;

            Console.WriteLine("\nDigite o novo nome do usuário:");
            newUser.Name = Console.ReadLine();

            Console.WriteLine("\nDigite o novo sobrenome do usuário:");
            newUser.LastName = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\nDigite a nova idade do usuário:");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    newUser.Age = age;
                    break;
                }
            }

            Console.WriteLine("\nDigite o novo email do usuário:");
            newUser.Email = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("\nDigite o novo telefone do usuário:");
                if (int.TryParse(Console.ReadLine(), out int tel))
                {
                    newUser.Tel = tel;
                    break;
                }
            }

            Console.WriteLine("\nDigite a nova nação do usuário:");
            newUser.Country = Console.ReadLine();

            users[idUser] = newUser;
        }

        void Delete()
        {
            int idUser;
            while (true)
            {
                Console.WriteLine("\nDigite o id do usuário a ser alterado:");
                if (int.TryParse(Console.ReadLine(), out idUser))
                    break;
            }

            users.Remove(users[idUser]);
        }
    }
}
