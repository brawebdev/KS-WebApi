﻿using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Commands
{
    public class ExistingUserCommand : IExistingUserCommand
    {
        private readonly IExistingUserReceiver _receiver;

        public ExistingUserCommand(IExistingUserReceiver receiver)
        {
            _receiver = receiver;
        }

        public async Task<DBExistingUserRAO> Execute(ExistingUserRAO userRAO)
        {
            return await _receiver.GetExistingUser(userRAO);
        }
    }
}
