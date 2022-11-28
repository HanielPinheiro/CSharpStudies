using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DataManipulation
    {
        private static  BusinessDataValidation businessValidator;
        private static  List<User> users;

        public DataManipulation()
        {
            businessValidator = new BusinessDataValidation();
            users = new List<User>();
        }

        public bool IdExist(int id)
        {
            if (users.Find(user => user.Id == id) != null))
                    return false;
            return true;
        }

        public bool EmailExist(int id)
        {
            if (users.Find(user => user.Id == id) != null))
                    return false;
            return true;
        }

        public bool PhoneExist(int id)
        {
            if (users.Find(user => user.Id == id) != null))
                    return false;
            return true;
        }

    }
}
