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
