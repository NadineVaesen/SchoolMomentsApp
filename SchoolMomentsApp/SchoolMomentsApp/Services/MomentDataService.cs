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
        private IMomentRepository _momentRepository;
        public MomentDataService(IMomentRepository momentRepository)
        {
            _momentRepository = momentRepository;
        }

        public async Task<Moment> AddRequestedStudent(int id, Moment moment)
        {
            return await _momentRepository.AddRequestedStudent(id, moment);
        }

        public async Task<IEnumerable<Moment>> GetAllMomentsAsync()
        { 
            return await _momentRepository.GetMomentsAsync();
        }

        public async Task<Moment> GetMomentAsync(int id)
        {
            return await _momentRepository.GetMoment(id);
        }

        
    }
}
