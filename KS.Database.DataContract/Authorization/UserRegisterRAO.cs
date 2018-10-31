using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Database.DataContract.Authorization
{
    public class UserRegisterRAO
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
