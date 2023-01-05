using Model;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;


namespace View.ConsoleApp
{
    internal class Operations
    {
        private ManipulateData insert = new ManipulateData();
        private static UserBLL userBLL = new UserBLL();

        public void Create()
        {
            User newUser = new User();
            newUser.Name = insert.InsertName();
            newUser.Age = insert.InsertAge();
            newUser.Email = insert.InsertEmail();

            userBLL.Create(newUser);

            Console.WriteLine("\nUser created succesfully");
            Console.ReadKey();
            Console.Clear();
        }
        public void Retrieve()
        {
            int choosedId = SelectIdToVerify();
            if (choosedId > 0)
            {
                Console.WriteLine("Press any key to back to menu.");
                Console.WriteLine("\nInformations:");
                User user = userBLL.Retrieve(choosedId);
                if (user != null)
                    Console.WriteLine("Id: " + user.Id + "\nName: " + user.Name + "\nAge: " + user.Age + "\nE-mail: " + user.Email);
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Update()
        {
            int choosedId = SelectIdToVerify();

            User userToUpdate = userBLL.FindUserById(choosedId);
            bool control = true;

            if (userToUpdate != null)
            {
                string choosedOperation = null;
                Console.WriteLine("\nChoose an operation: ");
                Console.WriteLine("\nName:'New name' - To update name\nAge:'New age' - To update age\nEmail:'New Email' - To update e-mail");
                Console.WriteLine("Insert 'Ctrl + Q' to Quit\n");
                while (control)
                {

                    Console.Write("Insert the operation: ");
                    ConsoleKeyInfo controlKeyInfo = Console.ReadKey();

                    if (controlKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && controlKeyInfo.Key == ConsoleKey.Q)
                        break;
                    else
                        choosedOperation = controlKeyInfo.Key + Console.ReadLine();
                    try
                    {
                        string[] splitedValues = choosedOperation.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                        string propertyName = userBLL.ReturnPropertieName(splitedValues[0]);
                        string propertyValue = splitedValues[1];
                        switch (propertyName)
                        {
                            case nameof(User.Name):
                                try
                                {
                                    userToUpdate.Name = userBLL.TypeName(propertyValue);
                                    userBLL.Update(userToUpdate);
                                    Console.WriteLine("\nUpdated succesfully\n");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;

                            case nameof(User.Age):
                                try
                                {
                                    userToUpdate.Age = userBLL.TypeAge(propertyValue);
                                    userBLL.Update(userToUpdate);
                                    Console.WriteLine("\nUpdated succesfully\n");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;

                            case nameof(User.Email):
                                try
                                {
                                    userToUpdate.Email = userBLL.TypeEmail(propertyValue);
                                    userBLL.Update(userToUpdate);
                                    Console.WriteLine("\nUpdated succesfully\n");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;

                            default:
                                Console.WriteLine("This property name don't exist, please insert a valid property name");
                                foreach (System.Reflection.PropertyInfo property in userBLL.GetPropertyInfos())
                                    if (property.Name != nameof(User.Id))
                                        Console.WriteLine("Propertie name: " + property.Name);

                                Console.WriteLine();
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\nInvalid Operation\n");
                    }


                }
            }
            else
                Console.WriteLine("\nDon't have this user in database");

            Console.Clear();
        }
        public void Delete()
        {
            int choosedId = SelectIdToVerify();
            if (choosedId > 0)
            {
                if (userBLL.Delete(choosedId))
                    Console.WriteLine("\nUser deleted succesfully");
                else
                    Console.WriteLine("\nDon't have this user in database");
            }

            Console.ReadKey();
            Console.Clear();
        }
        public int SelectIdToVerify()
        {
            Console.Clear();
            ListRegisterdIds();

            Console.WriteLine("\nPlease, select the id which you want to verify the informations");
            int id = insert.InsertId();

            if (userBLL.IsAnExistentId(id))
            {
                Console.Clear();
                Console.WriteLine("User found.");
                return id;
            }
            else
            {
                Console.WriteLine("\nYou insert an invalid id, please try again\n");
                return -1;
            }
        }
        public void ListRegisterdIds()
        {
            List<int> registeredIds = userBLL.GetIds();

            foreach (int id in registeredIds)
                Console.WriteLine("ID: " + id);
        }
        public void ListData()
        {
            Console.WriteLine($"\nHello, welcome to the Users and Contacts Manger, you have {userBLL.CountUsers()} users registered.");
            Console.WriteLine($"You can register until {UserValidator.availableContacts} users.");

            List<User> dataList = userBLL.ListData();

            if (dataList.Count() > 0)
            {
                Console.WriteLine("\nId | Name | Email");
                foreach (User orderedUser in dataList.OrderBy(p => p.Id).ToList())
                    Console.WriteLine(orderedUser.Id + " | " + orderedUser.Name + " | " + orderedUser.Email);
            }
            else
                Console.WriteLine("\nDatabase is empty!");
        }
    }
}
