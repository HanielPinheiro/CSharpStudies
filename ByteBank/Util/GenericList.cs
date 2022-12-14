using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Util
{
    public class GenericList<T>
    {
        public T GenericPropertie { get; set; }

        public void ShowData(T type)
        {
            Console.WriteLine($"Informed data = {type.ToString()}");
            Console.WriteLine($"Type = {type.GetType()}");
        }
    }
}
