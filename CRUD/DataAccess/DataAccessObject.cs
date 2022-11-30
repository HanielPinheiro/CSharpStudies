using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class DataAccessObject
    {
        private List<User> users = new List<User>();

        public int ListCount() { return users.Count; }

        public List<int> GetRegisteredIds()
        {
            List<int> registeredIds = new List<int>();
            foreach (User user in users.OrderBy(p => p.Id).ToList()) registeredIds.Add(user.Id);
            return registeredIds;
        }

        public int NewID(int limit)
        {
            List<int> registeredIds = GetRegisteredIds();
            List<int> availableIds = new List<int>();

            for(int i=1; i<= limit; i++)
            {
                if(!registeredIds.Contains(i))
                    availableIds.Add(i);
            }
            return availableIds.Min();
        }

        public bool IsEmailRegistered(string email)
        {
            List<string> emails = new List<string>();
            foreach (User user in users) emails.Add(user.Email);

            if (emails.Contains(email)) return true;
            return false;
        }

        public bool IsPhoneRegistered(long tel)
        {
            List<long> tels = new List<long>();
            foreach (User user in users) tels.Add(user.Tel);

            if (tels.Contains(tel)) return true;
            return false;
        }

        public bool Create(User newUser)
        {
            try { users.Add(newUser); return true; }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }

        public User Read(int id)
        {
            User targetUser = users.Find(p => p.Id == id);
            return targetUser;
        }

        public bool Delete(int id)
        {
            User targetUser = users.Find(p => p.Id == id);
            users.Remove(targetUser);
            return true;
        }

        public bool Update(User newUser, int id)
        {
            users.Remove(users.Find(p => p.Id == id));
            users.Add(newUser);
            return true;
        }
        public User FindUserById(int id){ return users.Find(p => p.Id == id); }

        public List<string> ListData()
        {
            List<string> returnList = new List<string>();            
            int total = users.Count();
            
            if (total > 0)
            {
                returnList.Add("\nId | Name | Email ");
                foreach(User orderedUser in users.OrderBy(p => p.Id).ToList())
                    returnList.Add(orderedUser.Id + " | " + orderedUser.Name + " | " + orderedUser.Email);
            }
            return returnList;
        }
    }
}
