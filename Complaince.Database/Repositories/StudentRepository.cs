using Complaince.Database.Infrastructure;
using Complaince.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaince.Database.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {

    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
