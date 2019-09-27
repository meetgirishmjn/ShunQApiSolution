using System.Threading.Tasks;

namespace BusinessCore.AppHandlers.Contracts
{
    public interface ILoggerManager
    {
        void LogError(string message);
        void LogInfo(string message);
        void LogWarning(string message);
    }
}
