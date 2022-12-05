using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserValidator
    {
        public static int availableContacts = 10;

        public bool IsValidId(string id)
        {
           if (id?.Length > 0 && int.TryParse(id, out int insertedId))
                return true;
           return false;
        }

        public bool IsValidName(string name)
        {
            if(name?.Length >= 3)
                return true;
            return false;
        }

        public bool IsValidAge(string age)
        {
            if (int.TryParse(age, out int result) && result > 17 && result < 100)
                return true;
            return false;
        }

        public bool IsValidEmail(string email)
        {
            if (email?.Length > 0 && email.Contains("@"))
                return true;
            return false;
        }

        public string TypeName(string name)
        {
            if (IsValidName(name))
                return name;
            return null;
        }

        public int TypeAge(string age)
        {
            if (IsValidAge(age))
                return Convert.ToInt32(age);
            return -1;
        }

        public string TypeEmail(string email)
        {
            if (IsValidEmail(email))
                return email;
            return null;
        }

        public void Validate(User user)
        {
            if (UserDAO.CountUsers() < availableContacts)
            {
                if (!IsValidName(user.Name))
                    throw new Exception("The name inserted is wrong, need to have more than 3 character.");

                if (!IsValidAge(user.Age.ToString()))
                    throw new Exception("The age inserted is wrong, need to be higher than 0.");

                if (!IsValidEmail(user.Email))
                    throw new Exception("The email inserted is wrong, need to have more than 3 character and a '@' symbol.");
                else if (UserDAO.IsEmailRegistered(user.Email))
                    throw new Exception("The email inserted was registered, insert another email.");
            }
            else
            {
                throw new Exception($"You can't assing more users, {availableContacts} users registered.");
            }
        }

    }
}
