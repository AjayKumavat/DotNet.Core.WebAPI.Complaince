using Complaince.Models;
using Complaince.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaince.API.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("Get")]
        [Produces(typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetStudentList()
        {
            IEnumerable<Student> student = await _studentService.GetAllStudent();
            return Ok(student);
        }

        [HttpPost]
        [Route("Add")]
        [Produces(typeof(Student))]
        public IActionResult AddStudent(Student student)
        {
            return Ok(_studentService.AddStudent(student));
        }

        [HttpPut]
        [Route("Update")]
        [Produces(typeof(Student))]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            return Ok(await _studentService.UpdateStudent(student));
        }

        [HttpDelete]
        [Route("Delete")]
        [Produces(typeof(bool))]
        public async Task<bool> DeleteStudent(int id)
        {
            return await _studentService.DeleteStudent(id);
        }
    }
}
