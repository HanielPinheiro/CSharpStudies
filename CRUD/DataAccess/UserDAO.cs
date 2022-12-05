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
    public static class UserDAO
    {
        private static List<User> users = new List<User>();
        private static int lastId = 0;

        static UserDAO()
        {
            User user1 = new User();
            user1.Id = UserDAO.NextID();
            user1.Name = "Haniel";
            user1.Age = 55;
            user1.Email = "haniel_pereira@hotmail.com";

            User user2 = new User();
            user2.Id = UserDAO.NextID();
            user2.Name = "Hanielzin";
            user2.Age = 45;
            user2.Email = "hanielzin@gmail.com";

            User user3 = new User();
            user3.Id = UserDAO.NextID();
            user3.Name = "Hanny Hanny";
            user3.Age = 38;
            user3.Email = "hannyH@pokemon.com";

            Create(user1);
            Create(user2);
            Create(user3);
        }

        public static int CountUsers()
        {
            return users.Count;
        }
        public static List<User> ListUsers()
        {
            return users;
        }
        public static User FindUserById(int id)
        {
            return users.Find(p => p.Id == id);
        }
        public static List<int> GetRegisteredIds()
        {
            return users.Select(p => p.Id).ToList();
        }
        public static int NextID()
        {
            return ++lastId;
        }
        public static bool IsEmailRegistered(string email)
        {
            return users.Any(p => string.Equals(p.Email, email, StringComparison.InvariantCultureIgnoreCase));
        }
        public static void Create(User newUser)
        {   
            try
            {
                users.Add(newUser);
            }
            catch (Exception)
            {
                throw new Exception($"Error when try to {nameof(Create)} user {newUser}");
            }
        }
        public static User Retrieve(int id)
        {
            try
            {
                User user = users.Find(p => p.Id == id);
                //User user1 = users.First(p => p.Id == id);  nao retorna null
                //User user2 = users.FirstOrDefault(p => p.Id == id);  retorna null
                //User user3 = users.Where(p => p.Id == id).First();  nao retorna null
                //User user4 = users.Where(p => p.Id == id).ToList()[0]; retorna null

                return user;
            }
            catch (Exception)
            {
                throw new Exception($"Error when try to {nameof(Retrieve)} data of user {id}");
            }
        }
        public static void Update(User newUser)
        {
            try
            {
                //Delete(newUser.Id);
                //users.Add(newUser);

                User user = users.Find(p => p.Id == newUser.Id);
                user.Name = newUser.Name;
                user.Email = newUser.Email;
                user.Age = newUser.Age;
            }
            catch (Exception )
            {
                throw new Exception($"Error when try to {nameof(Update)} user {newUser}");
            }
        }
        public static void Delete(int id)
        {
            try
            {
                users.Remove(users.Find(p => p.Id == id));
            }
            catch (Exception)
            {
                throw new Exception($"Error when try to {nameof(Delete)} user {id}");
            }
        }
    }
}
