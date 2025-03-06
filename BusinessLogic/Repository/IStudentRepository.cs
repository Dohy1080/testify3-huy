using CoreEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudent();
        Task<IEnumerable<Student>> SearchStudents(string searchTerm);
        Task<IEnumerable<Student>> GetStudents(int pageNumber, int pageSize);
        Task<int> GetTotalCount();
        Task AddStudent(Student student);
        Task<Student> GetStudentById(Guid id);
        Task DeleteStudent(Guid id);
        Task<IEnumerable<Student>> GetAllStudents();



    }
}