using BusinessLogic.Interface;
using CoreEntities.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace StudentTeacherManagementBE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }


        [HttpGet("get-all-student")]
        public IEnumerable<Student> GetAllStudents()
        {
            return this._studentService.GetAllStudent();
        }



        [HttpPost("search")]
        public async Task<IActionResult> SearchStudents([FromQuery] string name, [FromQuery] Guid? id = null)
        {
            IEnumerable<Student> students;

            if (id.HasValue)
            {
                // Tìm kiếm bằng ID
                var student = await _studentService.GetStudentById(id.Value);
                if (student != null)
                {
                    students = new List<Student> { student }; // Trả về danh sách với một học sinh tìm thấy
                }
                else
                {
                    return NotFound("Student not found.");
                }
            }
            else
            {
                // Tìm kiếm bằng từ khóa
                students = await _studentService.SearchStudents(name);
            }

            return Ok(students);
        }



        [HttpGet("phantrang")]
        public async Task<IActionResult> GetStudents([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var students = _studentService.GetStudents(pageNumber, pageSize);
            var totalCount = _studentService.GetTotalCount();

            var response = new
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Students = students
            };

            return Ok(response);
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] Student studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is null.");
            }

            await _studentService.AddStudent(studentDto);

            // Lấy danh sách học sinh sau khi thêm
            var students = _studentService.GetAllStudent();
            return Ok(students); // Trả về danh sách học sinh
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudent(id);

            // Lấy danh sách học sinh sau khi xóa
            var students = _studentService.GetAllStudent();
            return Ok(students); // Trả về danh sách học sinh
        }

    }

}