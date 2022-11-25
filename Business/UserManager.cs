using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserManager
    {
        private readonly UserValidate userValidate;

        public UserManager()
        {
            userValidate = new UserValidate();
        }

        public void Create(User user)
        {
            if (userValidate.IsValid(user))
            {
                UserDAO.Create(user);
            }
        }

        public User Retrieve(int id)
        {
            if (userValidate.IsValid(id))
                return UserDAO.Retrieve(id);

            return null;
        }

        public void Update(int id, User changedUser)
        {
            if (userValidate.IsValid(id) && userValidate.IsValid(changedUser))
                UserDAO.Update(id, changedUser);
        }

        public void Delete(int id)
        {
            if (userValidate.IsValid(id))
                UserDAO.Delete(id);
        }
    }
}
