using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employer
{
    internal class Programmer : Employers
    {
        public Programmer(string cpf, double wage) : base(cpf, wage)
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
