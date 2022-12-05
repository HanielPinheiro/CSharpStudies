using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace View.ConsoleApp
{
    public class InsertData
    {
        private UserValidator userValidator;

        public InsertData()
        {
            userValidator = new UserValidator();
        }

        public int InsertId()
        {
            while(true)
            {
                string id = Console.ReadLine();
                if (userValidator.IsValidId(id))
                    return Convert.ToInt32(id);
                else
                    Console.WriteLine("\nYou insert an invalid id, please select one number of the list.");
            }
        }

        public string InsertName()
        {            
            while (true)
            {
                Console.WriteLine("\nInsert name:");
                string name = Console.ReadLine();
                if (userValidator.IsValidName(name))
                    return name;
                else
                    Console.WriteLine("\nYou insert an invalid name.");
            }
        }

        public int InsertAge()
        {            
            while (true)
            {
                Console.WriteLine("\nInsert age:");
                string age = Console.ReadLine();
                if (userValidator.IsValidAge(age))
                    return Convert.ToInt32(age);
                else
                    Console.WriteLine("\nYou insert an invalid age.");
            }
        }

        public string InsertEmail()
        {            
            while (true)
            {
                Console.WriteLine("\nInsert email:");
                string email = Console.ReadLine();
                if (userValidator.IsValidEmail(email))
                    return email;
                else
                    Console.WriteLine("\ncYou insert an invalid email.");
            }
        }

    }
}
