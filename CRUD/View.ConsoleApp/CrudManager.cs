using Model;
using Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace View.ConsoleApp
{
    internal class CrudManager
    {

        private InsertData insert = new InsertData();
        private static DataManipulation manipulator = new DataManipulation();

        public void Create()
        {
            int id = manipulator.ReturnId();
            string name = insert.InsertName();
            string lastName = insert.InsertLastName();
            int age = insert.InsertAge();

            #region Email
            string email = insert.InsertEmail();
            while (true)
            {
                if (!manipulator.IsEmailRegistered(email)) { break; }
                else
                {
                    Console.WriteLine("\nEmail was registered, please insert the email again.");
                    email = insert.InsertEmail();
                }
            }
            #endregion

            #region Phone number
            long tel = insert.InsertTel();
            while (true)
            {
                if (!manipulator.IsPhoneRegistered(tel)) { break; }
                else
                {
                    Console.WriteLine("\nTelephone was registered, insert another.");
                    tel = insert.InsertTel();
                }
            }
            #endregion

            string country = insert.InsertNation();

            #region Add User to list
            User newUser = new User();
            newUser.Id = id;
            newUser.Name = name;
            newUser.LastName = lastName;
            newUser.Age = age;
            newUser.Email = email;
            newUser.Tel = tel;
            newUser.Country = country;
            if (manipulator.Create(newUser)) Console.WriteLine("\nUser registered successfully!");
            else Console.WriteLine("\nFail in register the new User.");
            #endregion
        }

        public int GetTargetId()
        {
            Console.WriteLine("\nPlease, select the id which you want to verify the informations\n");

            List<int> registeredIds = manipulator.GetIds();
            ListIds(registeredIds);

            int choosedId = insert.InsertId();

            while (true)
            {
                if (!registeredIds.Contains(choosedId))
                {
                    Console.WriteLine("\nYou inserted a inexistent id, please insert again.");
                    choosedId = insert.InsertId();
                }
                else
                    break;
            }

            return choosedId;
        }

        public void Read()
        {
            if (manipulator.GetCount() > 0)
            {
                int choosedId = GetTargetId();

                User targetUser = manipulator.Read(choosedId);
                if (targetUser != null)
                {
                    Console.WriteLine("\nId: " + targetUser.Id + "\nName: " + targetUser.Name + "\nLastname: " + targetUser.LastName + "\nAge: " + targetUser.Age +
                        "\nE-mail: " + targetUser.Email + "\nTel: " + targetUser.Tel + "\nCountry: " + targetUser.Country);
                }
                else Console.WriteLine("\nFailed in the process of read data, verify if user exists.");
            }
            else Console.WriteLine("\nHave no data to read.");
        }

        public void Update()
        {
            if (manipulator.GetCount() > 0)
            {
                int choosedId = GetTargetId();
                User updatedUser = manipulator.FindUserById(choosedId);
                string email = "";
                long tel = 0;
                bool control = true;

                while (control)
                {

                    Console.WriteLine("\nSelect one key to edit a option about this user: ");
                    Console.WriteLine("\nN - Update name\nL - Update Lastname\nA - Update age\nE - Update e-mail\nP - Update phone\nC - Update country");
                    Console.WriteLine("\nWhen finished press 'Esc' to turn back to menu ");
                    ConsoleKeyInfo key = Console.ReadKey();

                    switch (key.Key)
                    {
                        default:
                            Console.WriteLine("\nInvalid Console key!");
                            break;
                        case ConsoleKey.N:
                            updatedUser.Name = insert.InsertName();
                            break;
                        case ConsoleKey.L:
                            updatedUser.LastName = insert.InsertLastName();
                            break;
                        case ConsoleKey.A:
                            updatedUser.Age = insert.InsertAge();
                            break;
                        case ConsoleKey.E:
                            email = insert.InsertEmail();
                            while (true)
                            {
                                if (!manipulator.IsEmailRegistered(email)) { break; }
                                else
                                {
                                    Console.WriteLine("\nEmail was registered, please insert the email again.");
                                    email = insert.InsertEmail();
                                }
                            }
                            updatedUser.Email = email;
                            break;
                        case ConsoleKey.P:
                            tel = insert.InsertTel();
                            while (true)
                            {
                                if (!manipulator.IsPhoneRegistered(tel)) { break; }
                                else
                                {
                                    Console.WriteLine("\nTelephone was registered, insert another.");
                                    tel = insert.InsertTel();
                                }
                            }
                            updatedUser.Tel = tel;
                            break;
                        case ConsoleKey.C:
                            updatedUser.Country = insert.InsertNation();
                            break;
                        case ConsoleKey.Escape:
                            control = false;
                            break;
                    }
                }

                #region Add User to list
                if (manipulator.Update(updatedUser, choosedId)) Console.WriteLine("\nUser updated successfully!");
                else Console.WriteLine("\nFail in update the user → " + choosedId);
                #endregion
            }
            else Console.WriteLine("\nHave no data to update.");

        }

        public void Delete()
        {
            if (manipulator.GetCount() > 0)
            {
                int targetId = GetTargetId();
                if (manipulator.Delete(targetId)) Console.WriteLine("\nUser deleted successfully");
                else Console.WriteLine("\nUser not deleted, proccess failed, check id and try again");
            }
            else Console.WriteLine("\nHave no data to delete.");
        }

        public void ListData()
        {
            List<string> dataList = manipulator.ListData();
            if (dataList.Count() > 0)
                foreach (string userInfo in dataList) Console.WriteLine(userInfo);
            else
                Console.WriteLine("\nDatabase is empty!");
        }

        public void ListIds(List<int> registeredIds) { foreach (int id in registeredIds) Console.WriteLine("ID: " + id); }

        public int GetCount() { return manipulator.GetCount(); }
    }
}
