using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employer
{
    public interface IAuthenticable
    {
        string Password { get; set; }
        bool Authentify(string password);
        
    }
}
