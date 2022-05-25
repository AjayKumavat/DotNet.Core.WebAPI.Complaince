using Complaince.Database.Repositories;
using Complaince.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaince.Services
{
    public interface IAccountService
    {
        Task<UserLogin> Login(string userName, string password);
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<UserLogin> Login(string userName, string password)
        {
            return await _accountRepository.Login(userName, password);
        }
    }
}
