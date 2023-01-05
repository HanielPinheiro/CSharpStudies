using Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Business;
using System.Reflection;
using System.Web.UI;

namespace Business
{
    public class UserBLL
    {
        private UserValidator userValidator = new UserValidator();

        public int CountUsers()
        {
            return UserDAO.CountUsers();
        }

        #region Operations
        public void Create(User user)
        {
            try
            {
                userValidator.Validate(user);
                user.Id = UserDAO.NextID();
                UserDAO.Create(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public User Retrieve(int id)
        {
            try
            {
                return UserDAO.Retrieve(id);
            }
            catch
            {
                throw new Exception($"Fail in try to {nameof(Retrieve)} user");
            }
        }
        public void Update(User updatedUser)
        {
            try
            {
                UserDAO.Update(updatedUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"\nUpdate fail: {ex.Message}\n");
            }
        }
        public bool Delete(int id)
        {
            if (CountUsers() > 0)
            {
                try
                {
                    UserDAO.Delete(id);
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception($"Fail in try to {nameof(Delete)} user");
                }
            }
            else
                return false;
        }
        #endregion

        #region Utils
        public List<int> GetIds()
        {
            return UserDAO.GetRegisteredIds();
        }
        public bool IsAnExistentId(int id)
        {
            List<int> listOfIds = GetIds();
            return listOfIds.Contains(id);
        }
        public List<User> ListData()
        {
            return UserDAO.ListUsers();
        }
        public User FindUserById(int id)
        {
            return UserDAO.FindUserById(id);
        }
        #endregion

        #region Properties and Types
        public string TypeName(string info)
        {
            if (userValidator.TypeName(info) != null)
                return userValidator.TypeName(info);
            else
                throw new Exception($"Error when try to {nameof(TypeName)}");
        }
        public int TypeAge(string info)
        {

            if (userValidator.TypeAge(info) > 0)
                return userValidator.TypeAge(info);
            else
                throw new Exception($"Error when try to {nameof(TypeAge)}");
        }
        public string TypeEmail(string info)
        {
            if (userValidator.TypeEmail(info) != null)
                return userValidator.TypeEmail(info);
            else
                throw new Exception($"Error when try to {nameof(TypeEmail)}");
        }

        public List<PropertyInfo> GetPropertyInfos()
        {
            return typeof(User).GetProperties().ToList();
        }

        public string ReturnPropertieName(string propertyName)
        {
            List<PropertyInfo> properties = GetPropertyInfos();
            foreach (PropertyInfo property in properties)
                if (property.Name.ToLower() == propertyName.ToLower())
                    return property.Name;
            return null;
        }
        #endregion
    }
}


