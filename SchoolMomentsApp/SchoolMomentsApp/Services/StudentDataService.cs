using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public class StudentDataService : IStudentDataService
    {
        private IStudentRepository _studentRepository;

        public StudentDataService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            return _studentRepository.GetStudents();
        }

        public Task<Student> GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }
    }
}
