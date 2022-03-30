using LoginComponent.util;
using System.Security.Cryptography;

namespace LoginComponent
{
    public class LoginService : ILoginService
    {
        private DAO db;
        private EmailAndPasswordValidator validator;

        public LoginService(DAO db, EmailAndPasswordValidator validator)
        {
            this.db = db;
            this.validator = validator;
        }

        public bool Login(string email, string password)
        {
            if(!validator.isEmailValid(email) || !validator.isPasswordValid(password))
            {
                throw new ArgumentNullException();
            }

            return db.Login(email, password);;
        }

        public bool CreateLogin(string email, string password)
        {
            if(!validator.isEmailValid(email) || !validator.isPasswordValid(password))
            {
                throw new ArgumentNullException();
            }

            return db.CreateLogin(email, password);
        }

        public bool UpdateLogin(string email, string newPassword, string oldPassword)
        {
            if(!validator.isEmailValid(email) || !validator.isPasswordValid(newPassword) || oldPassword != null)
            {
                throw new ArgumentNullException();
            }

            return db.UpdateLogin(email, newPassword, oldPassword);
        }

        public HashAndSalt Hashing(string password)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            HashAndSalt hashResultSha256 = pwHasher.HashWithRandomSalt(password, 64, SHA256.Create());

            return hashResultSha256;
        }

        public string ReHashing(string password, string salt)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            HashAndSalt hashResultSha256 = pwHasher.HashWithSalt(password, salt, SHA256.Create());

            return hashResultSha256.Hash;
        }
    }
}
