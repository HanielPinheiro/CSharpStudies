using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ConsoleApp
{
    public class InputValidation
    {

        public bool IsInteger(string number)
        {
            return int.TryParse(number, out int result);
        }

        public bool IsLong(string number)
        {
            return long.TryParse(number, out long result);
        }

        public bool IsPositiveInteger(string number)
        {
            if (int.TryParse(number, out int result))
                if (result > 0) return true;
            return false;
        }
        public bool IsValidEmail(string email)
        {
            if (email?.Length > 0 && email.Contains("@"))
                return true;
            return false;
        }
        public bool IsValidTel(string tel)
        {
            if(tel?.Length>=12)
                return true;
            return false;
        }
    }
}
