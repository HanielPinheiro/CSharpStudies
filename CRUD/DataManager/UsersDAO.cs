using DataAccess;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataManager
{
    public class UsersDAO
    {
        static readonly List<User> users;
        static readonly DataValidation validator;
        static readonly DataManipulation manipulator;
        static UsersDAO()
        {
            users = new List<User>();
        }

        public List<string> ListUsers()
        {
            List<string> returnList = new List<string>();
            int total = users.Count();
            if (total > 0)
            {                
                returnList.Add("Id | Name | Email ");
                for (int user = 0; user < total; user++)                
                    returnList.Add(users[user].Id + " | " + users[user].Name + " | " + users[user].Email);                
            }
            return returnList;
        }

        public bool inputID(int idConverted)
        {
            if (validator.IsValidId(idConverted) && users.ElementAtOrDefault(idConverted) != null)
                return true;
            else
                return false;
        }


    }
}
