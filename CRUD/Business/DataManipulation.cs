using Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Business
{
    public class DataManipulation
    {
        private static DataAccessObject DAO = new DataAccessObject();
        private int count = 0;

        public void UpdateCount() { count = DAO.ListCount(); }

        public int GetCount() { UpdateCount(); return count; }

        public int ReturnId()
        {
            UpdateCount();
            return DAO.NewID();
        }
        public List<int> GetIds() { return DAO.GetRegisteredIds(); }

        public bool IsEmailRegistered(string email)
        {
            UpdateCount();
            if (count > 0) return DAO.IsEmailRegistered(email);
            else return false;
        }

        public bool IsPhoneRegistered(long tel)
        {
            UpdateCount();
            if (count > 0) return DAO.IsPhoneRegistered(tel);
            else return false;
        }

        public bool Create(User newUser) { return DAO.Create(newUser); }

        public User Read(int id) { return DAO.Read(id); }

        public bool Update(User updatedUser, int choosedId) { return DAO.Update(updatedUser, choosedId); }

        public bool Delete(int id) { return DAO.Delete(id); }

        public List<string> ListData() { return DAO.ListData(); }

        public User FindUserById(int id) {   return DAO.FindUserById(id);  }

    }
}
