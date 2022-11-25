using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class UserDAO
    {
        private static List<User> users = new List<User>();

        public static void Create(User user)
        {
            users.Add(user);
        }

        public static User Retrieve(int id)
        {
            return users.FirstOrDefault(p => p.Id == id);
        }

        public static void Update(int id, User changedUser)
        {
            var user = users.FirstOrDefault(p => p.Id == id);

            if (user != null)
            {
                user.Name = changedUser.Name;
                user.Age = changedUser.Age;
            }
        }

        public static void Delete(int id)
        {
            var user = users.FirstOrDefault(p => p.Id == id);
            users.Remove(user);
        }
    }
}
