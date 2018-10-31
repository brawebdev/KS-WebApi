using KS.Business.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.DataContract.Authorization
{
    public interface IExistingUserInvoker
    {
        Task<ReceivedExistingUserRAO> InvokeLoginCommand(QueryForExistingUserRAO userRAO);
    }
}
