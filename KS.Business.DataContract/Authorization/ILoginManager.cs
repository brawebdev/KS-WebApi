using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
    public interface ILoginManager
    {
        Task<ReceivedExistingUserDTO> LoginUser(QueryForExistingUserDTO userDTO);
        string GenerateTokenForUser(ReceivedExistingUserDTO receivedExistingUserDTO);
    }
}
