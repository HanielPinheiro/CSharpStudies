using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserValidate
    {
        public bool IsValid(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                return false;
            }

            if (user.Age < 18)
            {
                return false;
            }

            return true;
        }

        public bool IsValid(int id)
        {
            if (id == 0)
                return false;

            return true;
        }
    }
}
