using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public interface IAdministratorRepository
    {
        bool AdministratorExistByAdminNumber(string AdminNumber);
        Administrator GetAdministrator();
        Task<IEnumerable<Administrator>> GetAdministrators();
    }
}