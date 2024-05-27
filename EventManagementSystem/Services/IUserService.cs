using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface IUserService
    {
        User? User{ get; set; }
        bool IsAdmin { get; set; }
        bool IsLogin { get; set; }
        void SignIn();
        void SignOut();
    }
}
