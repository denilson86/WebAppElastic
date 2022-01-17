using System.Threading.Tasks;
using WebAppElastic.Models;

namespace WebAppElastic.Services
{
    public interface ILoggerService
    {
        Task<string> LogError(LoggerRequest request);
        Task<string> LogInformation(LoggerRequest request);
        Task<string> LogWarning(LoggerRequest request);
    }
}