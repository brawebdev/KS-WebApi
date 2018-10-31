using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.DataContract.Authorization
{
    public interface IExistingUserInvoker
    {
        Task<DBExistingUserRAO> InvokeLoginCommand(ExistingUserRAO userRAO);
    }
}
