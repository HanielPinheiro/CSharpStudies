using Model;
using BLL;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace View.Console
{
    internal class Operation
    {
        private ContactModel contact;
        private BusinessRules BLL;
        private InsertContactData insertContactData;

        #region Create
        public void Create()
        {
            try
            {
                System.Console.Clear();

                GenerateNewContact();

                if (BLL.CreateContact(contact))
                { 
                    System.Console.WriteLine("Contact created successfully");
                    contact = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void GenerateNewContact()
        {
            contact = new ContactModel();
            contact.ID = insertContactData.InsertIDNumber();
            InsertDataInContact();
        }

        public void InsertDataInContact()
        {            
            contact.Name = insertContactData.InsertFullName();
            contact.Email = insertContactData.InsertEmail();
            contact.Phone = insertContactData.InsertPhoneNumber();
            InsertContactAddress();
        }

        public void InsertContactAddress()
        {
            contact.Address.StreetName = insertContactData.InsertStreetAddress();
            contact.Address.Number = insertContactData.InsertNumberAddress();
            contact.Address.Complement = insertContactData.InsertAddressComplement();
        }
        #endregion

        //#region Retrieve
        //public void Retrieve()
        //{
        //    try
        //    {
        //        System.Console.Clear();
              
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //#endregion

        //#region Update
        //public void Update()
        //{
        //    try
        //    {
        //        System.Console.Clear();

        //        contact = ChooseContact();
        //        InsertDataInContact();

        //        if (BLL.UpdateContact(contact))
        //        {
        //            System.Console.WriteLine("Contact updated successfully");
        //            contact = null;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //#endregion

        //#region Delete
        //public void Delete()
        //{
        //    try
        //    {
        //        System.Console.Clear();

        //        string choosedPropertyToDeleteAContact = ChooseAWayToDeleteContact();

        //        if (choosedPropertyToDeleteAContact != null)
        //        {
        //            string userData = GetUserDataReferentToThePropertie(choosedPropertyToDeleteAContact);
        //            BLL.DeleteContact(userData, choosedPropertyToDeleteAContact);
        //        }
        //        else
        //            InvalidDeleteOption();  
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private string ChooseAWayToDeleteContact()
        //{
        //    System.Console.WriteLine("Do you want to delete a contact by:");

        //    List<PropertyInfo> propertiesName = typeof(ContactModel).GetProperties().Where(p => p.Name != "Address" && p.Name != "Name").ToList();
        //    foreach (var propertie in propertiesName)
        //        System.Console.WriteLine(propertie.Name);

        //    System.Console.WriteLine();

        //    return GetPropertyToDeleteAContact(propertiesName);
        //}

        //private string GetPropertyToDeleteAContact(List<PropertyInfo> propertiesName)
        //{            
        //    System.Console.WriteLine("Write the name of property:");
        //    string propertyName = System.Console.ReadLine();

        //    if (propertiesName.FirstOrDefault(p => p.Name == propertyName) != null)
        //        return propertyName;

        //    return null;
        //}

        //private string GetUserReferentToThePropertie(string propertyName)
        //{
        //    var listOfContacts = BLL.GetContactsList();
        //    if (propertyName == "Phone")
        //        return ChoiceContact(listOfContacts.Where(p => p.Phone), propertyName);

        //    if (propertyName == "Email")
        //        return ChoiceContact(listOfContacts.Where(p => p.Email), propertyName);

        //    if (propertyName == "IdentificationNumber")
        //        return ChoiceContact(listOfContacts.Where(p => p.ID), propertyName);

        //    return null;
        //}
        //private void InvalidDeleteOption()
        //{
        //    System.Console.WriteLine("Invalid option. Do you want to try again? (Y/N)");
        //    ConsoleKeyInfo tryAgain = System.Console.ReadKey();

        //    if (tryAgain.Key == ConsoleKey.Y)
        //        Delete();
        //}
        //#endregion
    }
}
