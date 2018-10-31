using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    public class LoginManager : ILoginManager
    {
        private readonly IExistingUserInvoker _loginInvoker;
        private readonly IMapper _mapper;

        public LoginManager(IExistingUserInvoker loginInvoker, IMapper mapper)
        {
            _loginInvoker = loginInvoker;
            _mapper = mapper;
        }

        public async Task<string> LoginUser(ExistingUserDTO userDTO)
        {
            var rao = PrepareRAOForLogin(userDTO);
            await _loginInvoker.InvokeLoginCommand(rao);

            return string.Empty;
        }

        private ExistingUserRAO PrepareRAOForLogin(ExistingUserDTO userDTO)
        {
            var rao = _mapper.Map<ExistingUserRAO>(userDTO);

            //var verifyPasswordHashEngine = new VerifyPasswordHashEngine();
            //var result = verifyPasswordHashEngine.VerifyPasswordHash(userDTO.Password, rao.PasswordHash, rao.PasswordSalt);

            return rao;
        }
    }
}
