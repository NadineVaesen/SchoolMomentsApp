using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}