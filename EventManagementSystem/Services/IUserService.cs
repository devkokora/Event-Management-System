using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface IUserService
    {
        Task Initialization { get; }
        void Initailize();
        void Clear();
    }
}
