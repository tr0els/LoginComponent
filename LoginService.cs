using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    public class LoginService : ILoginService
    {
        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool CreateLogin(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLogin(string email, string newPassword, string oldPassword)
        {
            throw new NotImplementedException();
        }

        public HashAndSalt Hashing(string password)
        {
            throw new NotImplementedException();
        }

        public string ReHashing(string password, string salt)
        {
            throw new NotImplementedException();
        }
    }
}
