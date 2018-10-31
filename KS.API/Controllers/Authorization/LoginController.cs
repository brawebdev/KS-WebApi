using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KS.API.Controllers.Authorization
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ILoginManager _loginManager;
        private readonly IMapper _mapper;

        public LoginController(ILoginManager loginManager, IMapper mapper)
        {
            _loginManager = loginManager;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            loginRequest.UserName = loginRequest.UserName.ToLower();
            var dto = _mapper.Map<ExistingUserDTO>(loginRequest);
            await _loginManager.LoginUser(dto);

            return StatusCode(200);
        }
    }
}
