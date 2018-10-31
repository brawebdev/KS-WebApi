using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Commands
{
    public class RegisterUserCreateCommand : IAuthorizationCommand
    {
        private readonly IAuthorizationReceiver _receiver;

        public RegisterUserCreateCommand(IAuthorizationReceiver receiver)
        {
            _receiver = receiver;
        }

        public async Task<bool> Execute(UserRegisterRAO userRAO)
        {
            return await _receiver.RegisterUser(userRAO);
        }
    }
}
