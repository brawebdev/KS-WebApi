using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace KS.Business.Engines.Authorization
{
    internal class CreatePasswordHashEngine
    {
        internal void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
