using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employer
{
    public class Director:Employers
    {
        public Director(string cpf, double wage) : base(cpf, wage)
        {
        }

        public override double Bonification()
        {
            return 0;
        }

        public override double GetWage()
        {
            return 0;
        }
    }
}
