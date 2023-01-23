using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace View.Console
{
    internal class Text
    {
        private BusinessRules BLL;

        /// <summary>
        /// This class only take care about the texts and messages, without variables, this make a the paper of a visual form
        /// </summary>
        
        public void ShowMenu()
        {
            System.Console.WriteLine("==============================");
            System.Console.WriteLine("=          Operations        =");
            System.Console.WriteLine("=            Press           =");
            System.Console.WriteLine("=       C - To Create        =");
            System.Console.WriteLine("=       R - To Retrieve      =");
            System.Console.WriteLine("=       U - To Update        =");
            System.Console.WriteLine("=       D - To Delete        =");
            System.Console.WriteLine("==============================");            
        }

        public void ShowContacts()
        {
            //System.Console.WriteLine("==================================================");
            //var listOfContacts = BLL.GetContactsList();
            //foreach (var contact in listOfContacts)
            //    System.Console.WriteLine($"{contact.ID} - {contact.FullName} -{contact.Email}");
            //System.Console.WriteLine("==================================================");
        }

        public void Welcome()
        {
            System.Console.WriteLine("==============================");
            System.Console.WriteLine("=     Contacts Scheduler     =");
            System.Console.WriteLine("=                            =");
            System.Console.WriteLine("=           Welcome!         =");
            System.Console.WriteLine("==============================");
        }

    }
}
