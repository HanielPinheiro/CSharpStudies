using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DataValidation
    {
        public bool IsValidId(int id)
        {
            if (id <= 0)
                return false;
            return true;
        }

        public bool IsValidAge(int age)
        {
            if (age < 18)
                return false;
            return true;
        }

        public bool IsValidEmail(string email)
        {
            if (!email.Contains("@"))
                return false;
            return true;

        }

    }
}
