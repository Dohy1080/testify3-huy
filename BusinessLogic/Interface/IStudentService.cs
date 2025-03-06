using BusinessLogic.Repository;
using CoreEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IStudentService
    {
        public List<Student> GetAllStudent();
        Task<IEnumerable<Student>> SearchStudents(string searchTerm);
        Task<IEnumerable<Student>> GetStudents(int pageNumber, int pageSize);
        Task<int> GetTotalCount();
        Task AddStudent(Student studentDto);
        Task<Student> GetStudentById(Guid id);
        Task DeleteStudent(Guid id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public List<Student> GetAllStudent()
        {
            return _repository.GetAllStudent();
        }

        public async Task<IEnumerable<Student>> SearchStudents(string name)
        {
            return await _repository.GetAllStudents()  // Lấy toàn bộ danh sách học sinh
                .ContinueWith(task => task.Result
                    .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))); // Sử dụng LINQ để tìm kiếm
        }
        public async Task<IEnumerable<Student>> GetStudents(int pageNumber, int pageSize)
        {
            return await _repository.GetStudents(pageNumber, pageSize);
        }

        public async Task<int> GetTotalCount()
        {
            return await _repository.GetTotalCount();
        }

        public async Task AddStudent(Student studentDto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),  // Tạo GUID mới
                Name = studentDto.Name,
                Gender = studentDto.Gender,
                Mail = studentDto.Mail,
                PhoneNumber = studentDto.PhoneNumber,
                BirthDate = studentDto.BirthDate,
                Image = studentDto.Image,
                FirstLogin = DateTime.UtcNow, // Hoặc giá trị phù hợp
                Subject = studentDto.Subject,
                StudentCode = studentDto.StudentCode
            };

            await _repository.AddStudent(student);
        }
        public async Task DeleteStudent(Guid id)
        {
            await _repository.DeleteStudent(id);
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return await _repository.GetStudentById(id);
        }


    }
}