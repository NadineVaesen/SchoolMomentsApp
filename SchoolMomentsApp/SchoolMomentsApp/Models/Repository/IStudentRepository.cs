using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public interface IStudentRepository
    {
        Task<Student> GetStudent(int id);
        Task<IEnumerable<Student>> GetStudents();
        bool StudentExistsByStudentNumber(string studentnumber);
    }
}