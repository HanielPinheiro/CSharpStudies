using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ConsoleApp
{
    public class InsertData
    {
        InputValidation inputValidation;
        public InsertData()
        {
            inputValidation = new InputValidation();
        }

        public int InsertID()
        {
            string idInserted = null;
            while (true)
            {
                Console.WriteLine("\nDigite o id do usuário:");
                idInserted = Console.ReadLine();

                if (inputValidation.IsPositiveInteger(idInserted))
                {
                    return Convert.ToInt32(idInserted);
                }
                else
                    Console.WriteLine("\nId inválido");
            }
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
            string ageInserted = null;

            while (true)
            {
                Console.WriteLine("\nDigite a idade do usuário:");
                ageInserted = Console.ReadLine();

                if (inputValidation.IsPositiveInteger(ageInserted))
                    return Convert.ToInt32(ageInserted);
                else
                    Console.WriteLine("\nIdade inválida");
            }

        }

        public string insertEmail()
        {
            string email = null;

            while (true)
            {
                Console.WriteLine("\nDigite o email do usuário:");
                email = Console.ReadLine();
                if (inputValidation.IsValidEmail(email))
                    return email;
                else
                    Console.WriteLine("\nEmail inválido");

            }
        }

        public long insertTel()
        {
            string tel = null;

            while (true)
            {
                Console.WriteLine("\nDigite o telefone do usuário com DDI e DDD (5511912345678):");
                tel = Console.ReadLine();
                if (inputValidation.IsValidTel(tel))
                    return long.Parse(tel);
                else
                    Console.WriteLine("\nTelefone inválido!");
            }
        }

        public string insertNation()
        {
            Console.WriteLine("\nDigite a nação do usuário:");
            return Console.ReadLine();
        }
    }
}
