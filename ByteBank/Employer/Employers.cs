using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employer
{
    public abstract class Employers
    {
        public string Name { get; set; }
        public string CPF { get; private set; }
        public double Wage { get; private set; }
        public static int totalEmployers = 0;

        public abstract double Bonification();

        public abstract double GetWage();
        public Employers(string cpf, double wage)
        {
            this.CPF = cpf;
            this.Wage = wage;
            totalEmployers++;
        }

    }
}
