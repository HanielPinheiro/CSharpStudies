using ByteBank.Employer;
using ByteBank.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.InternalSystem
{
    public class SystemManager
    {
        public bool Login(IAuthenticable user, string password)
        {
            bool userAuthentified = user.Authentify(password);
            if(userAuthentified)
            {
                Console.WriteLine("Welcome to our system.");
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password!");
                Console.WriteLine();
                return false;
            }
        }

    }
}
