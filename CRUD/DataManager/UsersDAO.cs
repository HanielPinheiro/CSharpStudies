using DataAccess;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataManager
{
    public class UsersDAO
    {
        static readonly List<User> users;
        static readonly DataValidation validator;
        static readonly DataManipulation manipulator;
        static UsersDAO()
        {
            users = new List<User>();
        }

        public void List()
        {
            int total = users.Count();
            if (total > 0)
            {
                Console.WriteLine("Id | Name | Email ");
                for (int user = 0; user < total; user++)
                {
                    Console.WriteLine("{0} | {1} | {2}  ", users[user].Id, users[user].Name, users[user].Email);
                }
            }
            else
                Console.WriteLine("BD vazio!");
        }

        public void Create()
        {
            User newUser = new User();
            newUser.Id = insertId();
            newUser.Name = insertName();
            newUser.LastName = insertLastName();
            newUser.Age = insertAge();
            newUser.Email = insertEmail();

            users.Add(newUser);
        }


        public int insertId()
        {
            int idConverted = -1;
            string idInserted = null;
            while (true)
            {
                Console.WriteLine("\nDigite o id do usuário:");
                idInserted = Console.ReadLine();

                if (validator.IsInteger(idInserted))
                {
                    idConverted = int.Parse(idInserted);
                    if (validator.IsValidId(idConverted) && users.ElementAtOrDefault(idConverted) != null)
                        break;
                }
                else
                    Console.WriteLine("\nId inválido");
            }
            idInserted = null;
            return idConverted;
        }

        public string insertName()
        {
            Console.WriteLine("\nDigite o nome do usuário:");
            return Console.ReadLine();
        }

        public string insertLastName()
        {        
            Console.WriteLine("\nDigite o sobrenome do usuário:");
            return Console.ReadLine();
        }
       
        public int insertAge()
        {
            int ageConverted = -1;
            string ageInserted = null;

            while (true)
            {
                Console.WriteLine("\nDigite o id do usuário:");
                ageInserted = Console.ReadLine();

                if (validator.IsValidAge(ageInserted))
                    ageConverted = int.Parse(ageInserted);
                else
                    Console.WriteLine("\nId inválido");
            }

            ageInserted = null;
            return ageConverted;
        }

        public string insertEmail()
        {
            string email = null;

            while (true)
            {
                Console.WriteLine("\nDigite o email do usuário:");
               email = Console.ReadLine();

                List<string> emails = new List<string>();
                foreach (User user in users) { emails.Add(user.Email) };

                if(!emails.Contains(email))     
                    break;
            }

            return email;
        }
        



while (true)
{
    Console.WriteLine("\nDigite o telefone do usuário com DDI e DDD (5511912345678):");
    string tel = Console.ReadLine();
    if (validator.IsValidTel(tel, users))
    {
        newUser.Tel = Convert.ToInt64(tel);
        break;
    }
    else
        Console.WriteLine("\nTelefone inválido!");
}

Console.WriteLine("\nDigite a nação do usuário:");
newUser.Country = Console.ReadLine();
    }
}
