using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employer
{
    public abstract class Authenticator : Employers, IAuthenticable
    {
        protected Authenticator(string cpf, double wage) : base(cpf, wage)
        {
        }

        public string Password { get; set; }

        public bool Authentify(string password)
        {
            return this.Password == password;
        }
    }
}
