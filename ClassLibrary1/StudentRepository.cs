using BusinessLogic.Repository;
using CoreEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerPlugin
{
    public class StudentRepository : IStudentRepository
    {
        private CustomDBContext _dbContext;
        public StudentRepository(CustomDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Student> GetAllStudent()
        {
            return _dbContext.Students.ToList();
        }

        public async Task<IEnumerable<Student>> SearchStudents(string searchTerm)
        {
            return await _dbContext.Students
                .Where(s => s.Name.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents(int pageNumber, int pageSize)
        {
            return await _dbContext.Students
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCount()
        {
            return _dbContext.Students.Count();
        }

        public async Task AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Student>> GetAllStudents() // Cài đặt phương thức này
        {
            return _dbContext.Students.ToList();
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return _dbContext.Students.Find(id);
        }

        public async Task DeleteStudent(Guid id)
        {
            var student = await GetStudentById(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
        }


    }
}