using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Console
{
    public class InsertContactData
    {
        internal string InsertIDNumber()
        {
            bool flag = false;
            string iD = null;

            while (flag)
            {
                System.Console.WriteLine("Please insert your Identification Number:");
                iD = System.Console.ReadLine();
                if (iD?.Length > 0)
                    flag = true;
                else
                    System.Console.WriteLine("Invalid ID Number");
            }

            return iD;
        }

        internal string InsertFullName()
        {
            bool flag = false;
            string fullName = null;

            while (flag)
            {
                System.Console.WriteLine("Please insert your Full Name:");
                fullName = System.Console.ReadLine();
                if (fullName?.Length > 0)
                    flag = true;
                else
                    System.Console.WriteLine("Invalid Full Name");
            }

            return fullName;
        }

        internal string InsertEmail()
        {
            bool flag = false;
            string email = null;

            while (flag)
            {
                System.Console.WriteLine("Please insert your Email:");
                email = System.Console.ReadLine();
                if (email?.Length > 0 && email.Contains("@"))
                    flag = true;
                else
                    System.Console.WriteLine("Invalid Email");
            }

            return email;
        }

        internal string InsertPhoneNumber()
        {
            bool flag = false;
            string phone = null;

            while (flag)
            {
                System.Console.WriteLine("Please insert your Phone Number:");
                phone = System.Console.ReadLine();
                if (phone?.Length > 0)
                    flag = true;
                else
                    System.Console.WriteLine("Invalid Phone Number");
            }

            return phone;
        }

        internal string InsertStreetAddress()
        {
            bool flag = false;
            string streetAddress = null;

            while (flag)
            {
                System.Console.WriteLine("Please insert your Street Address:");
                streetAddress = System.Console.ReadLine();
                if (streetAddress?.Length > 0)
                    flag = true;
                else
                    System.Console.WriteLine("Invalid Street Address");
            }

            return streetAddress;
        }

        internal string InsertNumberAddress()
        {
            bool flag = false;
            string numberAddress = null;

            while (flag)
            {
                System.Console.WriteLine("Please insert your Number Address:");
                numberAddress = System.Console.ReadLine();
                if (numberAddress?.Length > 0)
                    flag = true;
                else
                    System.Console.WriteLine("Invalid Number Address");
            }

            return numberAddress;
        }

        internal string InsertAddressComplement()
        {
                System.Console.WriteLine("Please insert your Address Complement:");
            string addressComplement = System.Console.ReadLine();
            return addressComplement;
        }
            
    }
}
