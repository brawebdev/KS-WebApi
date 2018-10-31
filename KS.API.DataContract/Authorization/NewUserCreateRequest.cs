using System;
using System.Collections.Generic;
using System.Text;

namespace KS.API.DataContract.Authorization
{
    public class NewUserCreateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
