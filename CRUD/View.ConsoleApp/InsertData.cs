﻿using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ConsoleApp
{
    public class InsertData
    {
        BusinessDataValidation dataManipulation;

        public InsertData()
        {
            dataManipulation = new BusinessDataValidation();
        }

        public int InsertID()
        {
            string idInserted = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user id:");
                idInserted = Console.ReadLine();

                if (dataManipulation.IsValidId(idInserted))
                    return Convert.ToInt32(idInserted);
                else
                    Console.WriteLine("\nInvalid id");
            }
        }

        public string InsertName()
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

        public string InsertLastName()
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


        public int InsertAge()
        {
            string ageInserted = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user age:");
                ageInserted = Console.ReadLine();
                if (dataManipulation.IsValidAge(ageInserted))
                    return Convert.ToInt32(ageInserted);
                else
                    Console.WriteLine("\nInvalid age");
            }

        }

        public string InsertEmail()
        {
            string email = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user email:");
                email = Console.ReadLine();
                if (dataManipulation.IsValidEmail(email))
                    return email;
                else
                    Console.WriteLine("\nInvalid email");

            }
        }

        public long InsertTel()
        {
            string tel = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user phone with DDD and DDI (5511912345678):");
                tel = Console.ReadLine();
                if (dataManipulation.IsValidTel(tel))
                    return long.Parse(tel);
                else
                    Console.WriteLine("\nInvalid Phone number!");
            }
        }

        public string InsertNation()
        {
            string nation = null;
            while (true)
            {
                Console.WriteLine("\nInsert the user country:");
                nation = Console.ReadLine();
                if (nation?.Length > 0)
                    return nation;
            }
        }
    }
}
