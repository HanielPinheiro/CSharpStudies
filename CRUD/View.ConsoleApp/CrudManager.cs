using Model;
using Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace View.ConsoleApp
{
    internal class CrudManager
    {

        private InsertData insert = new InsertData();
        private DataManipulation manipulator = new DataManipulation();

        public void Create()
        {
            User newUser = new User();

           
            int id = insert.InsertID();
            while (true){  if (manipulator.IdExist(id)) { break; } else { Console.WriteLine("Invalid Id"); id = insert.InsertID(); }; }          

            string name = insert.InsertName();
            string lastName = insert.InsertLastName();
            int age = insert.InsertAge();

            #region Email
            string email = insert.InsertEmail();
            while (true) {
                List<string> emails = new List<string>();
                foreach (User user in users)
                    emails.Add(user.Email);

                if (emails.Contains(email))
                {
                    Console.WriteLine("\nEmail was registered, please insert the email again.");
                    email = insert.InsertEmail();
                }
                else
                    break;
            }
            #endregion

            #region Phone number
            long tel = insert.InsertTel();
            while (true)
            {
                List<long> tels = new List<long>();
                foreach (User user in users)
                    tels.Add(user.Tel);

                if (tels.Contains(tel))
                {
                    Console.WriteLine("\nTelephone was registered, insert another.");
                    tel = insert.InsertTel();
                }
                else
                    break;
            }
            #endregion

            string country = insert.InsertNation();

            #region Add User to list
            newUser.Id = id;
            newUser.Name = name;
            newUser.LastName = lastName;
            newUser.Age = age;
            newUser.Email = email;
            newUser.Tel = tel;
            newUser.Country = country;
            users.Add(newUser);
            #endregion
        }

        public void Read()
        {
            Console.WriteLine("\nPlease, insert the id which you want to verify the informations");

            int id = insert.InsertID();
            User target = null;
            while (true)
            {
                if (users.Find(user => user.Id == id) == null)
                {
                    Console.WriteLine("\nPlease, verify and insert the ID again");
                    id = insert.InsertID();
                }
                else
                {
                    target = users.Find(user => user.Id == id);
                    break;
                }
            }

            Console.WriteLine("Id: " + target.Id + "\nName: " + target.Name + "\nLastname: " + target.LastName + "\nAge: " + target.Age +
                "\nEmail: " + target.Age + "\nTel: " + target.Tel + "\nCountry: " + target.Country);
        }

        public void Update()
        {
            #region ID
            int id = insert.InsertID();
            while (true)
            {
                if (users.Find(user => user.Id == id) == null)
                {
                    Console.WriteLine("\nPlease, verify and digit the ID which you want to update");
                    id = insert.InsertID();
                }
                else
                    break;

            }
            #endregion


            string name = insert.InsertName();
            string lastName = insert.InsertLastName();
            int age = insert.InsertAge();


            #region Email
            string email = insert.InsertEmail();
            while (true)
            {
                List<string> emails = new List<string>();
                foreach (User user in users)
                    emails.Add(user.Email);

                if (emails.Contains(email))
                {
                    Console.WriteLine("\nEmail was registered, please insert the email again.");
                    email = insert.InsertEmail();
                }
                else
                    break;
            }
            #endregion

            #region Phone number
            long tel = insert.InsertTel();
            while (true)
            {
                List<long> tels = new List<long>();
                foreach (User user in users)
                    tels.Add(user.Tel);

                if (tels.Contains(tel))
                {
                    Console.WriteLine("\nTelephone was registered, insert another.");
                    tel = insert.InsertTel();
                }
                else
                    break;
            }
            #endregion

            string country = insert.InsertNation();

            #region Update user
            User target = users.Find(user => user.Id == id);
            target.Name = name;
            target.LastName = lastName;
            target.Age = age;
            target.Email = email;
            target.Tel = tel;
            target.Country = country;
            #endregion
        }

        public void Delete()
        {
            Console.WriteLine("\nPlease insert the id which you want to delete from DB");

            #region ID
            int id = insert.InsertID();
            while (true)
            {
                if (listUsers.Find(user => user.Id == id) == null)
                {
                    Console.WriteLine("\nPlease, verify and digit the ID which you want to update");
                    id = insert.InsertID();
                }
                else
                    break;

            }
            #endregion

            User target = users.Find(user => user.Id == id);
            users.Remove(target);
            Console.WriteLine("\nUser deleted successfully");
        }

        public void ListData()
        {
            if (users.Count() > 0)
                foreach (User userInfo in users)
                    Console.WriteLine(userInfo.Id + " | " + userInfo.Name + " | " + userInfo.Email);
            else
                Console.WriteLine("Database is empty!");
        }

    }
}
