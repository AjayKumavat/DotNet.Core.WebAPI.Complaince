using Complaince.Database.Repositories;
using Complaince.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaince.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task<Student> GetStudentById(int id);
        Student AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Student AddStudent(Student student)
        {
            _studentRepository.Add(student);
            return student;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            Student student = await GetStudentById(id);
            if(student != null)
            {
                _studentRepository.Delete(student);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _studentRepository.Get();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetById(id);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            Student _student = await GetStudentById(student.Id);
            if(_student != null)
            {
                _student.Name = student.Name;
                _student.Email = student.Email;
                _student.Password = student.Password;
                _student.CreatedDate = DateTime.Now;
                _student.IsActive = student.IsActive;
                _studentRepository.Update(_student);
            }
            return _student;
        }
    }
}
