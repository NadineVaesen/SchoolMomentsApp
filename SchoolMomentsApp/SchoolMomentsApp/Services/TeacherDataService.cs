using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public class TeacherDataService : ITeacherDataService
 
    {
        private ITeacherRepository _teacherRepository;

        public TeacherDataService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return _teacherRepository.GetTeachers();
        }

        public Task<Teacher> GetTeacher(int id)
        {
            return _teacherRepository.GetTeacher(id);
        }
    }
}
