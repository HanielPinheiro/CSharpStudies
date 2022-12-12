using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employer
{
    public class Manager : Authenticator
    {
        public Manager(string cpf, double wage) : base(cpf, wage)
        {
        }

        public override double GetBonification()
        {
            return this.Wage * 0.15;
        }

        public override double UpWage()
        {
            return this.Wage *= 0.75;
        }
    }
}
