using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public class MomentDataService : IMomentDataService
    {
        public async Task<Moment> AddRequestedStudent(int id, Moment moment)
        {
            return await MomentRepository.AddRequestedStudent(id, moment);
        }

        public async Task<IEnumerable<Moment>> GetAllMomentsAsync()
        { 
            return await MomentRepository.GetMomentsAsync();
        }

        public async Task<Moment> GetMomentAsync(int id)
        {
            return await MomentRepository.GetMoment(id);
        }

        
    }
}
