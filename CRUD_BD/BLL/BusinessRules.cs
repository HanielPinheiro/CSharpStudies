using Model;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BusinessRules
    {
        private DAO ContactDAO;

        public bool CreateContact(ContactModel contact)
        {
            try
            {
                return true;
                //if (IsContactValid(contact))
                //    return DAO.InsertContact(contact);
                //else
                //    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteContact(ContactModel contact)
        {
            try
            {
                return true;
                //return DAO.DeleteContact(contact);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateContact(ContactModel contact)
        {
            try
            {
                return true;
                //if (IsContactValid(contact))
                //    return DAO.UpdateContact(contact);
                //else
                //    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ContactModel> GetContactsList()
        {
            try
            {
                return null;
               //return DAO.ListContacts();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsContactValid(ContactModel contact)
        {
            if (contact.Name == null || contact.Name.Length < 2)
                return false;
            if (contact.Email == null || contact.Email.Length < 2 || !contact.Email.Contains("@"))
                return false;
            if (contact.Phone == null || contact.Phone.Length < 8 || int.TryParse(contact.Phone, out int p))
                return false;
            if (contact.Address.StreetName == null || contact.Address.StreetName.Length < 2)
                return false;
            if (contact.Address.Number == null || contact.Address.Number.Length == 0)
                return false;

            return true;
        }
    }
}
