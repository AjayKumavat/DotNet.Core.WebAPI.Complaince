using Complaince.Database.Infrastructure;
using Complaince.DTO;
using Complaince.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaince.Database.Repositories
{
    public interface IAccountRepository : IRepository<UserLogin>
    {
        Task<UserLogin> Login(string userName, string password);
    }
    public class AccoundRepository : Repository<UserLogin>, IAccountRepository
    {
        public AccoundRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<UserLogin> Login(string userName, string password)
        {
            Student student = await _context.Students.Where(x => x.Name == userName && x.Password == password).FirstOrDefaultAsync();

            var userLogin = new UserLogin
            {
                UserName = student.Name,
                Password = student.Password
            };
            return userLogin;
        }
    }
}
