using DataManager;
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
        private UsersDAO DAO = new UsersDAO();
        private InsertData insert = new InsertData();

        public void Create()
        {
            int id = insert.InsertID();
            while (true)
            {
                if (!DAO.BusinessValidationNewID(id))
                {
                    Console.WriteLine("\nPlease, insert the ID again");
                    id = insert.InsertID();
                }
                else
                    break;
            }

            string name = insert.insertName();
            string lastName = insert.insertLastName();

            int age = insert.insertAge();
            while (true)
            {
                if (!DAO.BusinessValidationAge(age))
                {
                    Console.WriteLine("\nPlease, insert the age again");
                    age = insert.insertAge();
                }
                else
                    break;
            }

            string email = insert.insertEmail();
            while (true)
            {
                if (!DAO.BusinessValidationEmail(email))
                {
                    Console.WriteLine("\nPlease insert the email again");
                    email = insert.insertEmail();
                }
                else
                    break;
            }


            long tel = insert.insertTel();
            while (true)
            {
                if (!DAO.BusinessValidationTel(tel))
                {
                    Console.WriteLine("\nPlease insert the telephone again");
                    tel = insert.insertTel();
                }
                else
                    break;
            }

            string nation = insert.insertNation();

            ArrayList dataObject = new ArrayList() { id, name, lastName, age, email, tel, nation };
            DAO.Create(dataObject);
        }

        public void Read()
        {
            Console.WriteLine("\nPlease, please insert the id which you want to verify the informations");

            int id = insert.InsertID();
            while (true)
            {
                if (!DAO.BusinessValidationExistentID(id))
                {
                    Console.WriteLine("\nPlease, verify and insert the ID again");
                    id = insert.InsertID();
                }
                else
                    break;
            }

            ArrayList data = DAO.Read(id);
            if (data != null)
            {
                Console.WriteLine("Id: " + data[0]);
                Console.WriteLine("Name: " + data[1]);
                Console.WriteLine("Lastname: " + data[2]);
                Console.WriteLine("Age: " + data[3]);
                Console.WriteLine("Email: " + data[4]);
                Console.WriteLine("Tel: " + data[5]);
                Console.WriteLine("Country: " + data[6]);
            }
            else
                Console.WriteLine("Nonexistent id!");

        }

        public void Update()
        {
            int id = insert.InsertID();
            while (true)
            {
                if (!DAO.BusinessValidationExistentID(id))
                {
                    Console.WriteLine("\nPlease, verify and digit the ID which you want to update");
                    id = insert.InsertID();
                }
                else
                    break;
            }

            string name = insert.insertName();
            string lastName = insert.insertLastName();

            int age = insert.insertAge();
            while (true)
            {
                if (!DAO.BusinessValidationAge(age))
                {
                    Console.WriteLine("\nPlease, verify and insert the age again");
                    age = insert.insertAge();
                }
                else
                    break;
            }

            string email = insert.insertEmail();
            while (true)
            {
                if (!DAO.BusinessValidationEmail(email))
                {
                    Console.WriteLine("\nPlease, insert the email again");
                    age = insert.insertAge();
                }
                else
                    break;
            }

            long tel = insert.insertTel();
            while (true)
            {
                if (!DAO.BusinessValidationTel(tel))
                {
                    Console.WriteLine("\nPlease insert the telephone again");
                    tel = insert.insertTel();
                }
                else
                    break;
            }

            string nation = insert.insertNation();

            ArrayList dataObject = new ArrayList() { id, name, lastName, age, email, tel, nation };
            if (DAO.Update(dataObject))
                Console.WriteLine("\nUser updated");
        }

        public void Delete()
        {
            Console.WriteLine("\nPlease insert the id which you want to delete from DB");

            int id = insert.InsertID();
            while (true)
            {
                if (!DAO.BusinessValidationExistentID(id))
                {
                    Console.WriteLine("\nPlease, insert the id again");
                    id = insert.InsertID();
                }
                else
                    break;
            }

            if (DAO.Delete(id))
                Console.WriteLine("\nUser deleted successfully");
        }

        public void ListData()
        {
            List<string> data = DAO.ListUsers();

            if (data.Count() > 0)
                foreach (string userInfo in data)
                    Console.WriteLine(userInfo);
            else
                Console.WriteLine("Database is empty!");
        }

    }
}
