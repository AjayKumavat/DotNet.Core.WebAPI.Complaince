using Complaince.DTO;
using Complaince.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaince.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public AccountController(IAccountService accountService, ITokenService tokenService, IConfiguration config)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            UserLogin _userLogin = await _accountService.Login(userLogin.UserName, userLogin.Password);

            if(_userLogin == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token = _tokenService.CreateToken(_userLogin);
            return Ok(token);
        }
    }
}
