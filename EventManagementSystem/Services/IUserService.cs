using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface IUserService
    {
        Task Initialization { get; }
        bool IsInitialized { get; set; }
        void Initailize();
        void Clear();
    }
}
