using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DataValidation
    {
        public bool IsValidId(int id)
        {
            if (id <= 0)
                return false;

            return true;
        }

        public bool IsValidAge(int age)
        {
            if (age < 18)
                return false;

            return true;
        }

        //public bool IsValidTel(string tel, List<User> users)
        //{
        //    if (!long.TryParse(tel, out long result))
        //        return false;

        //    long telephone = long.Parse(tel);
        //    List<long> telephones = new List<long>();

        //    foreach (User user in users)
        //        telephones.Add(user.Tel);

        //    return !telephones.Contains(telephone);
        //}
    }
}
