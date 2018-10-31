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

        public async Task<ReceivedExistingUserDTO> LoginUser(QueryForExistingUserDTO userDTO)
        {
            var rao = _mapper.Map<QueryForExistingUserRAO>(userDTO);
            var queryForRAO = _mapper.Map<QueryForExistingUserRAO>(userDTO);

            var received = await _loginInvoker.InvokeLoginCommand(queryForRAO);

            var verifyPasswordEngine = new VerifyPasswordHashEngine();
            var passwordsMatch = verifyPasswordEngine.VerifyPasswordHash(userDTO.Password, received.PasswordHash, received.PasswordSalt);

            if (passwordsMatch)
            {
                return _mapper.Map<ReceivedExistingUserDTO>(received);
            }
            else
                throw new Exception("Passwords do not match!");
        }

        public string GenerateTokenForUser(ReceivedExistingUserDTO receivedExistingUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
