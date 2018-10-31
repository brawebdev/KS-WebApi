using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Invokers
{
    public class ExistingUserInvoker : IExistingUserInvoker
    {
        private readonly IExistingUserCommand _command;

        public ExistingUserInvoker(IExistingUserCommand command)
        {
            _command = command;
        }

        public async Task<DBExistingUserRAO> InvokeLoginCommand(ExistingUserRAO userRAO)
        {
            return await _command.Execute(userRAO);
        }
    }
}
