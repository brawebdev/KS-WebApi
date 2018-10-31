using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Business.DataContract.Authorization
{
    public class DBExistingUserDTO
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
