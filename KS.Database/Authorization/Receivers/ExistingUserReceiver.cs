﻿using AutoMapper;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Receivers
{
    public class ExistingUserReceiver : IExistingUserReceiver
    {
        private readonly KSContext _context;
        private readonly IMapper _mapper;

        public ExistingUserReceiver(KSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DBExistingUserRAO> GetExistingUser(ExistingUserRAO userRAO)
        {
           var entity =
               await
                _context
                    .UserTableAccess
                    .FirstOrDefaultAsync(x => x.UserName == userRAO.Username);

            var loginRAO = _mapper.Map<DBExistingUserRAO>(entity);

            return loginRAO;
        }
    }
}
