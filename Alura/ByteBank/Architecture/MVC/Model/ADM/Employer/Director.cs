using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employer
{
    public class Director:Authenticator
    {
        public Director(string cpf, double wage) : base(cpf, wage)
        {
        }

        public override double GetBonification()
        {
            return this.Wage * 0.25;
        }

        public override double UpWage()
        {
            return this.Wage *= 1.05;
        }
    }
}
