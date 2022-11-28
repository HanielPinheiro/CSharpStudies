using DataAccess;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Linq;

namespace DataManager
{
    public class UsersDAO
    {
        private static readonly DataValidation validator = new DataValidation();
        private static readonly DataManipulation manipulator = new DataManipulation();

        public UsersDAO()
        {
            manipulator.users = new List<User>();
        }

        public bool BusinessValidationNewID(int id)
        {
            if (validator.IsValidId(id))
                if (manipulator.users.Count > 0 && manipulator.users.Find(p => p.Id == id) == null)
                    return true;
                else if(manipulator.users.Count == 0)
                    return true;
            return false;
        }

        public bool BusinessValidationExistentID(int id)
        {
            if (validator.IsValidId(id))
                if (manipulator.users.Count > 0 && manipulator.users.Find(p => p.Id == id) != null)
                    return true;
            return false;
        }

        public bool BusinessValidationAge(int id)
        {
            if (validator.IsValidAge(id))
                return true;
            return false;
        }

        public bool BusinessValidationEmail(string email)
        {
            if (validator.IsValidEmail(email))
            {
                List<string> emails = new List<string>();
                foreach (User user in manipulator.users)
                    emails.Add(user.Email);

                if (emails.Contains(email))
                {
                    Console.WriteLine("\nEmail was registered");
                    return false;
                }

                return true;
            }
            return false;
        }

        public bool BusinessValidationTel(long tel)
        {
            List<long> tels = new List<long>();
            foreach (User user in manipulator.users)
                tels.Add(user.Tel);

            if (tels.Contains(tel))
            {
                Console.WriteLine("\nTelephone was registered");
                return false;
            }
            return true;
        }

        public bool Create(ArrayList dataObject)
        {
            return manipulator.Create(dataObject);
        }
        public ArrayList Read(int id)
        {
            ArrayList data = manipulator.Read(id);
            if (data.Count > 0)
                return data;
            return null;
        }

        public bool Update(ArrayList dataObject)
        {
            return manipulator.Update(dataObject);
        }
        public bool Delete(int id)
        {
            return manipulator.Delete(id);
        }

        public List<string> ListUsers()
        {
            return manipulator.listData();
        }


    }
}
