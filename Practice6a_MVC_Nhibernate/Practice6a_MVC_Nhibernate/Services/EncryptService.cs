using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Services
{
    public class EncryptService : IEncryptService
    {   
        public byte[] HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
                Console.WriteLine("passwordBytes Password (SHA256): " + passwordBytes);

                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string a = BitConverter.ToString(hashBytes);
                return hashBytes;

            }
        }
    }
}