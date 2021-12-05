using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public interface IMomentRepository
    {
        Task<Moment> AddRequestedStudent(int id, Moment moment);
        Task<Moment> GetMoment(int id);
        Task<IEnumerable<Moment>> GetMomentsAsync();
    }
}