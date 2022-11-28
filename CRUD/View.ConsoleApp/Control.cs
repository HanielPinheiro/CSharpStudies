using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ConsoleApp
{
    public class Control
    {
        InsertData insert;
        public Control()
        {
            insert = new InsertData();
        }

        public void Create()
        {
            User newUser = new User();
            newUser.Id = insertId();
            newUser.Name = insertName();
            newUser.LastName = insertLastName();
            newUser.Age = insertAge();
            newUser.Email = insertEmail();

            users.Add(newUser);
        }
        
    }
}
