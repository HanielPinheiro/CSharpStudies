﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessDataValidation
    {
        public bool IsValidId(string id)
        {
            if (IsPositiveInteger(id))
                if (Convert.ToInt32(id) <= 0)
                    return false;
                else
                    return true;
            else
                return false;
        }

        public bool IsValidAge(string age)
        {
            if (IsPositiveInteger(age))
                if (Convert.ToInt32(age) <= 18)
                    return false;
                else
                    return true;
            else
                return true;
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
            if (tel?.Length >= 12)
                return true;
            return false;
        }

    }
}