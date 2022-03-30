using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static System.Security.Cryptography.RandomNumberGenerator;

namespace LoginComponent.util
{
    public class PasswordWithSaltHasher
    {
        
        public HashAndSalt HashWithSalt(string password, string salt, HashAlgorithm hashAlgo)
        {
            RNG rng = new RNG();
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
            HashAndSalt hs = new();
            hs.Salt = Encoding.UTF8.GetString(saltBytes);
            hs.Hash = Convert.ToBase64String(digestBytes);
            return hs;
        }

        public HashAndSalt HashWithRandomSalt(string password, int saltLength, HashAlgorithm hashAlgo)
        {
            RNG rng = new RNG();
            string salt = rng.GenerateRandomCryptographicKey(saltLength);

            return HashWithSalt(password, salt, hashAlgo);
        }
    }
}

