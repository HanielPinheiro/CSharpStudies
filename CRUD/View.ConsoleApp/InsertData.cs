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
                Console.WriteLine("\nInsert the user id:");
                idInserted = Console.ReadLine();

                if (inputValidation.IsPositiveInteger(idInserted))
                {
                    return Convert.ToInt32(idInserted);
                }
                else
                    Console.WriteLine("\nInvalid id");
            }
        }

        public string insertName()
        {
            string name = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user name:");
                name = Console.ReadLine();
                if (name?.Length > 0)
                    return name;
            }

        }

        public string insertLastName()
        {
            string lastName = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user lastname:");
                lastName = Console.ReadLine();
                if (lastName?.Length > 0)
                    return lastName;
            }
        }


        public int insertAge()
        {
            string ageInserted = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user age:");
                ageInserted = Console.ReadLine();
                if (inputValidation.IsPositiveInteger(ageInserted) && ageInserted?.Length > 0)
                    return Convert.ToInt32(ageInserted);
                else
                    Console.WriteLine("\nInvalid age");
            }

        }

        public string insertEmail()
        {
            string email = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user email:");
                email = Console.ReadLine();
                if (inputValidation.IsValidEmail(email))
                    return email;
                else
                    Console.WriteLine("\nInvalid email");

            }
        }

        public long insertTel()
        {
            string tel = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user phone with DDD and DDI (5511912345678):");
                tel = Console.ReadLine();
                if (inputValidation.IsValidTel(tel))
                    return long.Parse(tel);
                else
                    Console.WriteLine("\nInvalid Phone!");
            }
        }

        public string insertNation()
        {
            string nation = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user coutry:");
                nation = Console.ReadLine();
                if (nation?.Length > 0)
                    return nation;
            }            
        }
    }
}
