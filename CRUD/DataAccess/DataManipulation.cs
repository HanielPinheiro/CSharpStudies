using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class DataManipulation
    {
        public List<User> users { get; set; }
       
        public bool Create(ArrayList dataObject)
        {
            User newUser = new User();
            newUser.Id = (int)dataObject[0];
            newUser.Name = (string)dataObject[1];
            newUser.LastName = (string)dataObject[2];
            newUser.Age = (int)dataObject[3];
            newUser.Email = (string)dataObject[4];
            newUser.Tel = (long)dataObject[5];
            newUser.Country = (string)dataObject[6];
            users.Add(newUser);
            return true;
        }

        public ArrayList Read(int id)
        {
            ArrayList data = new ArrayList();
            if (users.Find(p => p.Id == id) != null)
            {
                User targetUser = users[id];                
                data.Add(targetUser.Id);
                data.Add(targetUser.Name);
                data.Add(targetUser.LastName);
                data.Add(targetUser.Age);
                data.Add(targetUser.Email);
                data.Add(targetUser.Tel);
                data.Add(targetUser.Country);
            }
            return data;
        }

        public bool Delete(int id)
        {
            User targetUser = users[id];
            users.Remove(targetUser);
            return true;
        }

        public bool Update(ArrayList dataObject)
        {
            int id = (int)dataObject[0];
            User targetUser = users.Find(p => p.Id == id);
            targetUser.Name = (string)dataObject[1];
            targetUser.LastName = (string)dataObject[2];
            targetUser.Age = (int)dataObject[3];
            targetUser.Email = (string)dataObject[4];
            targetUser.Tel = (long)dataObject[5];
            targetUser.Country = (string)dataObject[6];
            return true;
        }

        public List<string> listData()
        {
            List<string> returnList = new List<string>();
            int total = users.Count();
            if (total > 0)
            {
                returnList.Add("\nId | Name | Email ");
                for (int user = 0; user < total; user++)
                    returnList.Add(users[user].Id + " | " + users[user].Name + " | " + users[user].Email);
            }
            return returnList;
        }
    }
}
