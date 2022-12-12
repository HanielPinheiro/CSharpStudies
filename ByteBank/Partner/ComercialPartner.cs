using ByteBank.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Partner
{
    public class ComercialPartner:IAuthenticable
    {
        public string Password { get; set; }
        public bool Authentify(string password)
        {
            return this.Password == password;
        }
    }
}
