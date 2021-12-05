using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetTeacher(int id);
        Task<IEnumerable<Teacher>> GetTeachers();
        bool TeacherExistsByTeacherNumber(string teachernumber);
    }
}