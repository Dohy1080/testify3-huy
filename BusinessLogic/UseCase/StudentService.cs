using BusinessLogic.Interface;
using BusinessLogic.Repository;
using CoreEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.UseCase
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public List<Student> GetAllStudent()
        {
            return _studentRepository.GetAllStudent();
        }

        public Task<IEnumerable<Student>> SearchStudents(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetStudents(int pageNumber, int pageSize)
        {
            return await _studentRepository.GetStudents(pageNumber, pageSize);
        }

        public async Task<int> GetTotalCount()
        {
            return await _studentRepository.GetTotalCount();
        }

        public Task AddStudent(Student studentDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        public async Task DeleteStudent(Guid id)
        {
            await _studentRepository.DeleteStudent(id);
        }



    }
}